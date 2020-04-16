﻿using System;
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
        private int port;
        private string connectionColor;

        public ConnectionViewModel(ITelnetClient model)
        {
            IP = System.Configuration.ConfigurationManager.AppSettings["ip"];
            Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["port"]);

            this.model = model;
            //this.model.connect(this.ip, this.port);
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("Vm" + e.PropertyName);
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

        public String VmIsConnected
        {
            get
            {
                return this.model.IsConnected;
            }
        }

        public String VmConnectionColor
        {
            get
            {
                return this.model.ConnectionColor;
            }
        }
        public void connectToSimulator ()
        {
            model.connect(IP, Port);
        }
        public void disconnectSimulator()
        {
            model.disconnect();
        }
    }
}
