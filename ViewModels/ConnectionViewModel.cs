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

        public ConnectionViewModel(ITelnetClient model)
        {
            this.model = model;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public void connectToSimulator (string ip, int port)
        {
            model.connect(ip, port);
        }
        public void disconnectSimulator()
        {
            model.disconnect();
        }
    }
}
