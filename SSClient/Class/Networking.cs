using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SSClient.Class
{
    public static class Networking
    {
        #region "Windows Library Call"
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);
        #endregion

        #region "Method"
        public static string GetClientMAC(string strClientIP)
        {
            string mac_dest = "";
            try
            {
                Int32 ldest = inet_addr(strClientIP);
                Int32 lhost = inet_addr("");
                Int64 macinfo = new Int64();
                Int32 len = 6;
                int res = SendARP(ldest, 0, ref macinfo, ref len);
                string mac_src = macinfo.ToString("X");

                while (mac_src.Length < 12)
                {
                    mac_src = mac_src.Insert(0, "0");
                }

                for (int i = 0; i < 11; i++)
                {
                    if (0 == (i % 2))
                    {
                        if (i == 10)
                        {
                            mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                        else
                        {
                            mac_dest = "-" + mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception("L?i " + err.Message);
            }
            return mac_dest;
        }

        public static void Wake(string macaddress)
        {
            UdpClient udpClient = new UdpClient();

            // enable UDP broadcasting for UdpClient
            udpClient.EnableBroadcast = true;

            var dgram = new byte[1024];

            // 6 magic bytes
            for (int i = 0; i < 6; i++)
            {
                dgram[i] = 255;
            }

            // convert MAC-address to bytes
            byte[] address_bytes = new byte[6];
            for (int i = 0; i < 6; i++)
            {
                address_bytes[i] = byte.Parse(macaddress.Substring(3 * i, 2), NumberStyles.HexNumber);
            }

            // repeat MAC-address 16 times in the datagram
            for (int i = 0; i < 16; i++)
            {
                address_bytes.CopyTo(dgram, (i + 1) * 6);
            }

            // send datagram using UDP and port 0
            udpClient.Send(dgram, dgram.Length, new System.Net.IPEndPoint(IPAddress.Broadcast, 9));
            udpClient.Close();
        }

        #endregion
    }
}
