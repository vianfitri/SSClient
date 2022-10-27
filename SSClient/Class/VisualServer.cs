using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSClient.Class
{
    public static class VisualServer
    {
        public static ServerVisual visualconn = new ServerVisual();
    }

    public class ServerVisual
    {
        #region "Struct"
        public struct MyClient
        {
            public long id;
            public TcpClient client;
            public NetworkStream stream;
            public byte[] buffer;
            public StringBuilder data;
            public EventWaitHandle handle;
        };
        #endregion

        #region "Fields"
        private bool active = false;
        private Thread listener = null;
        private long id = 0;
        public ConcurrentDictionary<long, MyClient> clients = new ConcurrentDictionary<long, MyClient>();
        private Task send = null;
        private Thread disconnect = null;
        private bool exit = false;

        private float draftAft;
        private float draftFwd;
        #endregion

        #region "Constructor"
        public ServerVisual()
        {

        }
        #endregion

        #region "Method"
        private void Active(bool status)
        {
            if (!exit)
            {
                active = status;
                if (status)
                {
                    Console.WriteLine("Visual Server has started");
                }
                else
                {
                    Console.WriteLine("Visual Server has stopped");
                }
            }
        }

        private void Read(IAsyncResult result)
        {
            MyClient obj = (MyClient)result.AsyncState;
            int bytes = 0;
            if (obj.client.Connected)
            {
                try
                {
                    bytes = obj.stream.EndRead(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Visual Read Error : " + ex.Message);
                }
            }
            if (bytes > 0)
            {
                obj.data.AppendFormat("{0}", Encoding.UTF8.GetString(obj.buffer, 0, bytes));
                try
                {
                    if (obj.stream.DataAvailable)
                    {
                        obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(Read), obj);
                    }
                    else
                    {
                        // get data from visual application
                        string msg = string.Format("{0}", obj.data);
                        ParsingData(msg);
                        Console.WriteLine(msg);
                        obj.data.Clear();
                        obj.handle.Set();
                    }
                }
                catch (Exception ex)
                {
                    obj.data.Clear();
                    Console.WriteLine(ex.Message);
                    obj.handle.Set();
                }
            }
            else
            {
                obj.client.Close();
                obj.handle.Set();
            }
        }

        private void Connection(MyClient obj)
        {
            clients.TryAdd(obj.id, obj);
            Console.WriteLine("Visual Client has connected");

            while (obj.client.Connected)
            {
                try
                {
                    obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(Read), obj);
                    obj.handle.WaitOne();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            obj.client.Close();
            clients.TryRemove(obj.id, out MyClient tmp);
            Console.WriteLine("Visual Client has disconnected");
        }

        private void Listener(IPAddress ip, int port)
        {
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(ip, port);
                listener.Start();
                Active(true);
                while (active)
                {
                    if (listener.Pending())
                    {
                        try
                        {
                            MyClient obj = new MyClient();
                            obj.id = id;
                            obj.client = listener.AcceptTcpClient();
                            obj.stream = obj.client.GetStream();
                            obj.buffer = new byte[obj.client.ReceiveBufferSize];
                            obj.data = new StringBuilder();
                            obj.handle = new EventWaitHandle(false, EventResetMode.AutoReset);
                            Thread th = new Thread(() => Connection(obj))
                            {
                                IsBackground = true
                            };
                            th.Start();
                            id++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Listener : " + ex.Message);
                        }
                    }
                    else
                    {
                        Thread.Sleep(500);
                    }
                }
                Active(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Listener : " + ex.Message);
            }
            finally
            {
                if (listener != null)
                {
                    listener.Server.Close();
                }
            }
        }

        private void Write(IAsyncResult result)
        {
            MyClient obj = (MyClient)result.AsyncState;
            if (obj.client.Connected)
            {
                try
                {
                    obj.stream.EndWrite(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Write : " + ex.Message);
                }
            }
        }

        private void BeginWrite(string msg) // send the message to everyone
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            foreach (KeyValuePair<long, MyClient> obj in clients)
            {
                if (obj.Value.client.Connected)
                {
                    try
                    {
                        obj.Value.stream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(Write), obj.Value);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("BeginWrite : " + ex.Message);
                    }
                }
            }
        }

        public void Send(string msg)
        {
            if (send == null || send.IsCompleted)
            {
                send = Task.Factory.StartNew(() => BeginWrite(msg));
            }
            else
            {
                send.ContinueWith(antecendent => BeginWrite(msg));
            }
        }

        private void Disconnect() // disconnect everyone
        {
            if (disconnect == null || !disconnect.IsAlive)
            {
                disconnect = new Thread(() =>
                {
                    foreach (KeyValuePair<long, MyClient> obj in clients)
                    {
                        obj.Value.client.Close();
                    }
                })
                {
                    IsBackground = true
                };
                disconnect.Start();
            }
        }

        public void StartServer()
        {
            if (active)
            {
                active = false;
            }
            else if (listener == null || !listener.IsAlive)
            {
                string number = "3993";
                bool error = false;

                int port = -1;
                error = !int.TryParse(number, out port);
                if (!error)
                {
                    listener = new Thread(() => Listener(IPAddress.Loopback, port))
                    {
                        IsBackground = true
                    };
                    listener.Start();
                }
            }
        }

        public void ClosingServer()
        {
            exit = true;
            active = false;
            Disconnect();
        }

        private void ParsingData(string msg)
        {
            string[] split_data = msg.Split(',');

            if(split_data[0] == "ExtDraft")
            {
                draftAft = float.Parse(split_data[1]);
                draftFwd = float.Parse(split_data[2]);
            }
        }
        #endregion
    }
}

