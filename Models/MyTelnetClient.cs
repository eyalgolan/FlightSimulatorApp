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
        private static object lockReadWrite;
        private string isConnected;
        private string connectionColor;
        private static MyTelnetClient instance = null;
        public static MyTelnetClient Instance
        {
            /* 
             * We are generating a generic server form, but with a small and interesting addition that will give us colorful clues about connecting
               Red disconnected And green is connected
               also yellow marks a communication problem or slow connection
            */
            get
            {
                // using singeltone design pattern to have one object of the class, for all models
                if (instance == null)
                {
                    instance = new MyTelnetClient();
                    instance.IsConnected = "Disconected";
                    instance.ConnectionColor = "Red";
                    lockReadWrite = new object();
                }
                return instance;
            }
        }

        //INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        // connect command 
        public void connect(string ip, string port)
        {
            try
            {
                int connectionPort = int.Parse(port);
                ep = new IPEndPoint(IPAddress.Parse(ip), connectionPort);
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
        // disconnect command 

        public void disconnect()
        {
            try
            {
                client.Close();
                IsConnected = "Disconnected";
                ConnectionColor = "Red";
            }
            catch (Exception)
            {
                IsConnected = "Disconnected";
                ConnectionColor = "Red";
            }
        }

        // read function, responsible for updating information from the server 
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
                                // timeout check
                                client.ReceiveTimeout = 7000;

                                numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);

                                IsConnected = "Connected";
                                ConnectionColor = "Green";
                            }
                            catch (Exception)
                            {
                                // slow conaction 
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

        // write function, responsible for updating the server with set commands from the user
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

        //Properties

        // Property holding the connection status
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
        // Property holding the appropriate color based on the connection status
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
