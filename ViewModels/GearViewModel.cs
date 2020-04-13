using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlightSimulatorApp.Models;

namespace FlightSimulatorApp.ViewModels
{
    
    public class GearViewModel : INotifyPropertyChanged
    {
        private double rudder;
        private double elevator;
        private double aileron;
        private double throttle;

        //IGearModel model;
        public double VM_RUDDER
        {
            get
            {
                return this.rudder;
            }
            set
            {
                this.rudder = value;
                NotifyPropertyChanged("RUDDER");
            }
        }
        public double VM_ELEVATOR
        {
            get
            {
                return this.elevator;
            }
            set
            {
                this.elevator = value;
                NotifyPropertyChanged("ELEVATOR");
            }
        }
        public double VM_THROTTLE
        {
            get
            {
                return this.throttle;
            }
            set
            {
                this.throttle = value;
                NotifyPropertyChanged("THROTTLE");
            }
        }
        public double VM_AILERON
        {
            get
            {
                return this.aileron;
            }
            set
            {
                this.aileron = value;
                NotifyPropertyChanged("AILERON");
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
    }
}
