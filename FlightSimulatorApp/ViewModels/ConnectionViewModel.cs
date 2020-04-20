using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlightSimulatorApp.Models;

namespace FlightSimulatorApp.ViewModels
{
    public class ConnectionViewModel : INotifyPropertyChanged
    {
        ITelnetClient model;
        private string ip;
        private string port;

        public ConnectionViewModel(ITelnetClient model)
        {
            IP = System.Configuration.ConfigurationManager.AppSettings["ip"];
            Port = System.Configuration.ConfigurationManager.AppSettings["port"];

            this.model = model;
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("Vm" + e.PropertyName);
            };
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

        //Properties

        //Property responsible for holding the server's IP address
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

        //Property responsible for holding the server's port
        public string Port
        {
            get
            {
                return this.port;
            }
            set
            {
                int number = 0;
                bool canConvert = int.TryParse(value, out number);
                if (canConvert)
                {
                    this.port = value;
                }
            }
        }

        //Property responsible for relaying if the application is connected to the sever by text
        public String VmIsConnected
        {
            get
            {
                return this.model.IsConnected;
            }
        }

        //Property responsible for relaying if the application is connected to the sever by color
        public String VmConnectionColor
        {
            get
            {
                return this.model.ConnectionColor;
            }
        }

        //function responsible to send IP,port to the model in order to connect to the server
        public void ConnectToSimulator()
        {
            model.Connect(IP, Port);
        }

        //function responsible to send a disconnect request to the model
        public void DisconnectSimulator()
        {
            model.Disconnect();
        }
    }
}
