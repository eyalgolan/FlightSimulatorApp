using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Models
{
    class MyTelnetClient : ITelnetClient
    {
        TcpClient client;
        IPEndPoint ep;

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
        public void connect(string ip, int port)
        {
            ep = new IPEndPoint(IPAddress.Parse(ip), port);  
            client = new TcpClient();
            
            client.Connect(ep);
        }

        public void disconnect()
        {
            client.Close();
        }

        public string read()
        {
                NetworkStream myNetworkStream = client.GetStream();
                if (myNetworkStream.CanRead)
                {
                    byte[] myReadBuffer = new byte[1024];
                    StringBuilder myCompleteMessage = new StringBuilder();
                    int numberOfBytesRead = 0;
                    do
                    {
                        numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);

                        myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
                    }
                    while (myNetworkStream.DataAvailable);
                    // Print out the received message to the console.
                    Console.WriteLine("You received the following message : " +
                                                 myCompleteMessage);
                    return myCompleteMessage.ToString();

                }
                else
                {
                    Console.WriteLine("Sorry.  You cannot read from this NetworkStream.");
                    return null;

                }
        }


        public void write(string command)
        {
                NetworkStream nwStream = client.GetStream();

                if (nwStream.CanWrite)
                {
                    byte[] byteToSend = ASCIIEncoding.ASCII.GetBytes(command);
                    nwStream.Write(byteToSend, 0, byteToSend.Length);
                    nwStream.Flush();
                }
                else
                {
                    Console.WriteLine(" You cannot write to this.");
                }
        }
    }
}
