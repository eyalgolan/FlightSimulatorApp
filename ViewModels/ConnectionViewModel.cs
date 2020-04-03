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
        ITelnetStatus statusModel;
        private string ip;
        private int port;

        public ConnectionViewModel(ITelnetClient model, ITelnetStatus statusModel)
        {
            this.model = model;
            this.statusModel = statusModel;
            this.statusModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
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
                return this.statusModel.IsConnected;
            }
        }

        public String VM_ConnectionColor
        {
            get
            {
                Console.WriteLine(this.statusModel.ConnectionColor);
                return this.statusModel.ConnectionColor;
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
