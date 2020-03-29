using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlightSimulatorApp.Models;

namespace FlightSimulatorApp.ViewModels
{
    class ConnectionViewModel
    {
        ITelnetClient model;
        private string ip;
        private int port;

        public ConnectionViewModel(ITelnetClient model)
        {
            this.model = model;
        }

        public String IP
        {
            get
            {
                return this.ip;
            }
            set
            {
                this.ip = value;
            }
        }

        public int Port
        {
            get
            {
                return this.port;
            }
            set
            {
                this.port = value;
            }
        }
        public void connectToSimulator ()
        {
            Console.WriteLine(IP);
            Console.WriteLine(Port);
            model.connect(IP, Port);
  
        }
        public void disconnectSimulator()
        {
            model.disconnect();
        }
    }
}
