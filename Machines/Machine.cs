using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Machines
{
    [Serializable()]
    public class Machine
    {
        #region "Delegates"
        public delegate void StatusChangeEventHandler(string Name, StatusCodes status, string IpAddress);
        #endregion

        #region "External Library"

        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref byte[] mac, ref Int32 length);

        #endregion

        #region "Fields"
        [NonSerialized] private BackgroundWorker _backgroundWorker = new BackgroundWorker();
        [NonSerialized] private Ping ping = new Ping();

        public enum StatusCodes : int
        {
            Online,
            Offline,
            Unknown,
            Fail,
            Uninitialized
        }

        [XmlIgnore()] public StatusCodes Status = StatusCodes.Uninitialized;
        [NonSerialized] [XmlIgnore()] public PingReply Reply;
        [NonSerialized] [XmlIgnore()] public Semaphore Pool;
        [NonSerialized] [XmlIgnore()] const string data = "abcdefghijklmnopqrstuvwabcdefghi";
        [NonSerialized] [XmlIgnore()] private byte[] buffer = Encoding.ASCII.GetBytes(data);
        [NonSerialized] [XmlIgnore()] public string message;

        #endregion

        #region "Constructor"
        public Machine()
        {
            _backgroundWorker.WorkerSupportsCancellation = true;
            _backgroundWorker.DoWork += DoWork;
            _backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            _backgroundWorker.RunWorkerCompleted += RunWorkerCompleted;
        }

        #endregion

        #region "Properties"
        public string Name { get; set; } = string.Empty;
        public string MAC { get; set; } = string.Empty;
        public string IP { get; set; }= string.Empty;
        public string Netbios { get; set; } = string.Empty;
        #endregion

        #region "Methode"
        public void Run()
        {
            if (_backgroundWorker.IsBusy)
                return;
            _backgroundWorker.WorkerReportsProgress = true;
            if (string.IsNullOrEmpty(IP))
                return;
            _backgroundWorker.RunWorkerAsync(IP);
        }

        public bool IsBusy()
        {
            return _backgroundWorker.IsBusy;
        }

        public void Cancel()
        {
            _backgroundWorker.CancelAsync();
        }

        public override string ToString()
        {
            return "Machine : " + Name;
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                try
                {
                    PingOptions options = new PingOptions(128, true);
                    Pool.WaitOne();
                    Reply = ping.Send(IPAddress.Parse((string)e.Argument), 10000, buffer, options);

                    switch (Reply.Status)
                    {
                        case IPStatus.Success:
                            _backgroundWorker.ReportProgress((int)StatusCodes.Online);
                            break;
                        case IPStatus.TimedOut:
                        case IPStatus.DestinationNetworkUnreachable:
                        case IPStatus.DestinationHostUnreachable:
                            _backgroundWorker.ReportProgress((int)StatusCodes.Offline);
                            break;
                        default:
                            _backgroundWorker.ReportProgress((int)StatusCodes.Unknown);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    _backgroundWorker.ReportProgress((int)StatusCodes.Fail);
                }
                finally
                {
                    Pool.Release();
                    Thread.Sleep(2000);
                }
            } while (!_backgroundWorker.CancellationPending);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            StatusCodes newStatus;
            string newIpAddress = string.Empty;

            try
            {
                if (_backgroundWorker.CancellationPending)
                    return;

                switch (e.ProgressPercentage)
                {
                    case (int)StatusCodes.Online:
                        newStatus = StatusCodes.Online;
                        foreach (IPAddress ipAddress in from IPA1 in Dns.GetHostAddresses(Netbios)
                                                        where IPA1.AddressFamily.ToString() == "InterNetwork"
                                                        select IPA1)
                        {
                            if (IP == string.Empty)
                                newIpAddress = ipAddress.ToString();
                            else
                                newIpAddress = IP;

                            if (Status == StatusCodes.Uninitialized)
                            {
                                // if the host is DHCP, try to resolve the correct IP and verify the MAC.
                                // if we cannot find a matching interface with our MAC, assume the host is OFFLINE.
                                if (IP == string.Empty)
                                {
                                    newStatus = StatusCodes.Offline;

                                    int remoteIp;
                                    byte[] remoteMac = new byte[6];
                                    int len = 6;
                                    int dWord;

                                    try
                                    {
                                        remoteIp = ipAddress.GetHashCode();

                                        if (remoteIp != 0)
                                        {
                                            dWord = SendARP(remoteIp, 0, ref remoteMac, ref len);
                                            if (dWord == 0 | dWord == 67)
                                            {
                                                // 
                                                // we found a matching MAC, the host is officially ONLINE
                                                // 67 = ERROR_BAD_NET_NAME: if host on another subnet, just ignore the error
                                                // 
                                                if (CompareMac(BitConverter.ToString(remoteMac, 0, remoteMac.Length), MAC) == 0 | dWord == 67)
                                                {
                                                    newStatus = StatusCodes.Online;
                                                    newIpAddress = ipAddress.ToString();

                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }

                        if ((Status != newStatus))
                        {
                            Status = newStatus;
                            StatusChange?.Invoke(Name, Status, newIpAddress);
                        }
                        break;
                    case (int)StatusCodes.Offline:
                        if(Status != StatusCodes.Offline)
                        {
                            Status = StatusCodes.Offline;
                            StatusChange?.Invoke(Name, Status, string.Empty);
                        }
                        break;
                    case (int)StatusCodes.Unknown:
                    case (int)StatusCodes.Fail:
                    case (int)StatusCodes.Uninitialized:
                        if(Status != StatusCodes.Unknown)
                        {
                            Status = StatusCodes.Unknown;
                            StatusChange?.Invoke(Name, Status, message);
                        }
                        break;
                }
            }
            catch(Exception ex)
            {
                Debug.Fail(ex.Message);
            }
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Status = StatusCodes.Unknown;
                StatusChange?.Invoke(Name, Status, string.Empty);
            }
            catch (Exception ex)
            {
                Debug.Fail(ex.Message);
            }
        }

        private Int32 CompareMac(string mac1, string mac2)
        {
            string _mac1 = mac1.Replace(":", string.Empty);
            _mac1 = _mac1.Replace("-", string.Empty);

            string _mac2 = mac2.Replace(":", string.Empty);
            _mac2 = _mac2.Replace("-", string.Empty);

            return string.Compare(_mac1, _mac2);
        }
        #endregion

        #region "Events"
        public event StatusChangeEventHandler StatusChange;
        #endregion
    }
}
