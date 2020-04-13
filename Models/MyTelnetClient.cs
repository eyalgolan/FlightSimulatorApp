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
        private static object lockReadWrite = new object();
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
                    instance.IsConnected = "Discconected";
                    instance.ConnectionColor = "Red";
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
            catch (Exception)
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

        public string read()
        {
            lock (lockReadWrite)
            {
                try
                {
                    NetworkStream myNetworkStream = client.GetStream();

                    if (myNetworkStream.CanRead)
                    {
                        byte[] myReadBuffer = new byte[1024];
                        StringBuilder myCompleteMessage = new StringBuilder();
                        int numberOfBytesRead = 0;

                        do
                        {
                            try
                            {
                                client.ReceiveTimeout = 10000;

                                numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);

                                IsConnected = "Connected";
                                ConnectionColor = "Green";
                            }
                            catch (Exception)
                            {
                                IsConnected = "Server timeout";
                                ConnectionColor = "Yellow";
                            }

                            myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
                        }
                        while (myNetworkStream.DataAvailable);
                        return myCompleteMessage.ToString();
                    }
                    else
                    {
                        IsConnected = "Disconnected";
                        ConnectionColor = "Red";
                        return null;
                    }
                }
                catch (Exception)
                {
                    IsConnected = "Disconnected";
                    ConnectionColor = "Red";
                    return null;
                }
            }
        }


        public void write(string command)
        {
            lock (lockReadWrite)
            {
                try
                {
                    NetworkStream nwStream = client.GetStream();
                    if (nwStream.CanWrite)
                    {
                        try
                        {
                            byte[] byteToSend = ASCIIEncoding.ASCII.GetBytes(command);
                            nwStream.Write(byteToSend, 0, byteToSend.Length);
                            IsConnected = "Connected";
                            ConnectionColor = "Green";
                            nwStream.Flush();
                        }
                        catch (Exception)
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
                catch (Exception)
                {
                    IsConnected = "Disconnected";
                    ConnectionColor = "Red";
                }
            }
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
