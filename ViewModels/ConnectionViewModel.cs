using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlightSimulatorApp.Models;

namespace FlightSimulatorApp.ViewModels
{
    class ConnectionViewModel : INotifyPropertyChanged
    {
        ITelnetClient model;
        private string ip;
        private int port;
        private string connectionColor;

        public ConnectionViewModel(ITelnetClient model)
        {
            this.model = model;
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
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

        public String VM_IsConnected
        {
            get
            {
                return this.model.IsConnected;
            }
        }

        public String VM_ConnectionColor
        {
            get
            {
                return this.model.ConnectionColor;
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
