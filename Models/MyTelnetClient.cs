using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulatorApp.Models
{
    class MyTelnetClient : ITelnetClient
    {
        private TcpClient client;
        private IPEndPoint ep;
        private Mutex lockReadWrite = new Mutex();
        private static object lockReadWrite1 = new object();
        private string isConnected;
        private string connectionColor;
        private static MyTelnetClient instance = null;
        public static MyTelnetClient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MyTelnetClient();
                }
                return instance;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(String propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public void connect(string ip, int port)
        {
            try
            {
                ep = new IPEndPoint(IPAddress.Parse(ip), port);
                client = new TcpClient();
                client.Connect(ep);
                IsConnected = "Connected";
                ConnectionColor = "Green";
            }
            catch (Exception ex)
            {
                IsConnected = "Disconnected";
                ConnectionColor = "Red";
            }
        }

        public void disconnect()
        {
            client.Close();
            IsConnected = "Disconnected";
            ConnectionColor = "Red";
        }

        public async Task<string> read()
        {
            NetworkStream myNetworkStream;
            try
            {
                myNetworkStream = client.GetStream();
            }
            catch (Exception)
            {
                IsConnected = "Disconnected";
                ConnectionColor = "Red";
                return null;
            }

            try
            {
                client.ReceiveTimeout = 10000;
                byte[] myReadBuffer = new byte[1024];
                lockReadWrite.WaitOne();
                int numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);
                lockReadWrite.ReleaseMutex();
                IsConnected = "Connected";
                ConnectionColor = "Green";
                return System.Text.Encoding.UTF8.GetString(myReadBuffer, 0, myReadBuffer.Length); 
            }
            catch (Exception)
            {
                IsConnected = "Server timeout";
                ConnectionColor = "Yellow";
                return null;
            }
            //Console.WriteLine("try read bedore lock ");
            //lock (lockReadWrite)
            //{
                //Console.WriteLine("try after bedore lock ");

            //try
            //{
            //    NetworkStream myNetworkStream = client.GetStream();
            //    if (myNetworkStream.CanRead)
            //    {

            //        byte[] myReadBuffer = new byte[1024];
            //        StringBuilder myCompleteMessage = new StringBuilder();
            //        int numberOfBytesRead = 0;
            //        do
            //        {
            //            try
            //            {
            //                client.ReceiveTimeout = 10000;
            //                // TODO: change to async
            //                 numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);
            //            }
            //            catch (Exception ex)
            //            {
            //                IsConnected = "Server timeout";
            //                ConnectionColor = "Yellow";
            //                break;
            //            }

            //            myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
            //        }
            //        while (myNetworkStream.DataAvailable);
            //        IsConnected = "Connected";
            //        ConnectionColor = "Green";
            //        return myCompleteMessage.ToString();

            //    }
            //    else
            //    {
            //        IsConnected = "Disconnected";
            //        ConnectionColor = "Red";
            //        return null;
            //    }
            //}
            //catch (Exception ex)
            //{
                    
            //    IsConnected = "Disconnected";
            //    ConnectionColor = "Red";
            //    return null;
            //}
            //}
        }


        public async Task write(string command)
        {
            //Console.WriteLine("try write bedore lock ");

            //lock (lockReadWrite)
            //{
                //Console.WriteLine("try write after lock ");

                try
                {
                    NetworkStream nwStream = client.GetStream();

                    if (nwStream.CanWrite)
                    {
                        try
                        {
                            byte[] byteToSend = ASCIIEncoding.ASCII.GetBytes(command);
                            //lockReadWrite.WaitOne();
                            await nwStream.WriteAsync(byteToSend, 0, byteToSend.Length);
                            //lockReadWrite.ReleaseMutex();
                            IsConnected = "Connected";
                            ConnectionColor = "Green";
                            nwStream.Flush();
                        }
                        catch (Exception ex)
                        {
                            IsConnected = "Disconnected";
                            ConnectionColor = "Red";
                        }
                    }
                    else
                    {
                        IsConnected = "Disconnected";
                        ConnectionColor = "Red";
                    }
                }
                catch (Exception ex)
                {
                    IsConnected = "Disconnected";
                    ConnectionColor = "Red";

                }

            //}
        }

        public bool areconected()
        {
            if (this.IsConnected == "Connected")
            {
                return true;
            }
            else return false;
        }

        public String IsConnected
        {
            get
            {
                return this.isConnected;
            }
            set
            {
                this.isConnected = value;
                NotifyPropertyChanged("IsConnected");
            }
        }
        public String ConnectionColor
        {
            get
            {
                return this.connectionColor;
            }
            set
            {
                this.connectionColor = value;
                NotifyPropertyChanged("ConnectionColor");
            }
        }
    }
}
