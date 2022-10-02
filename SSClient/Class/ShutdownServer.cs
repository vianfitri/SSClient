using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Machines;
using SSClient.Class;
using SSClient.Forms;

namespace SSClient.Class
{
    public static class ShutdownServer
    {
        #region " Fields"
        public static TcpListener shutdownServerListener = new TcpListener(IPAddress.Parse("127.0.0.1"),7979);
        static TcpClient client;
        public static Dictionary<string, TcpClient> clientList = new Dictionary<string, TcpClient>();
        static CancellationTokenSource cancellation = new CancellationTokenSource();
        static List<string> chat = new List<string>();
        #endregion

        #region "Method"
        public static void Initiate()
        {
            cancellation = new CancellationTokenSource(); //resets the token when the server restarts
            startServer();
        }

        public static async void startServer()
        {
            shutdownServerListener.Start();
            Console.WriteLine("Server Started at " + shutdownServerListener.LocalEndpoint);

            try
            {
                int counter = 0;
                while (true)
                {
                    counter++;
                    client = await Task.Run(() => shutdownServerListener.AcceptTcpClientAsync(), cancellation.Token);

                    int n = MachineModule.Machines.Count;
                    int ci = 0;
                    foreach(Machine m in MachineModule.Machines)
                    {
                        if(m.IP == ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString())
                        {
                            Console.WriteLine("Client connected on " + m.IP);
                            clientList.Add(m.Name, client);
                            break;
                        }
                        ci++;
                        Console.WriteLine("ci : " + ci);
                    }
                    if (ci == n)
                        client.Close();

                    await Task.Delay(1000).ContinueWith(t => Console.WriteLine(counter));
                }
            }
            catch(Exception)
            {
                shutdownServerListener.Stop();
            }
        }

        public static void ShutdownAll()
        {
            try
            {
                foreach (var Item in clientList)
                {
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    Byte[] broadcastBytes = null;

                    chat.Add("gPower");
                    broadcastBytes = ObjectToByteArray(chat);

                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    broadcastStream.Flush();
                    
                    // Remove broadcastSocket from list
                    chat.Clear();
                }
            }
            catch (Exception er)
            {

            }
        }

        public static void ShutdownClient(string Name)
        {
            try
            {                    
                chat.Clear();
                chat.Add("gPower");
                byte[] byData = ObjectToByteArray(chat);
                TcpClient workerSocket = null;
                workerSocket = (TcpClient)clientList.FirstOrDefault(x => x.Key == Name).Value; //find the client by username in dictionary

                NetworkStream stm = workerSocket.GetStream();
                stm.Write(byData, 0, byData.Length);
                stm.Flush();
                chat.Clear();
            }
            catch (Exception er) { }
        }

        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        #endregion
    }
}
