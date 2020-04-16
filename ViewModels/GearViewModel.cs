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
        IGearModel model;
        private double rudder;
        private double elevator;
        private double aileron;
        private double throttle;

        //IGearModel model;
        public GearViewModel(IGearModel model)
        {
            this.model = model;
        }
        public double VmRudder
        {
            get
            {
                return this.rudder;
            }
            set
            {
                this.rudder = value;
                this.model.setRudder(this.rudder);
            }
        }
        public double VmElevator
        {
            get
            {
                return this.elevator;
            }
            set
            {
                this.elevator = value;
                this.model.setElevator(this.elevator);
            }
        }
        public double VmThrottle
        {
            get
            {
                return this.throttle;
            }
            set
            {
                this.throttle = value;
                this.model.setThrottle(this.throttle);
            }
        }
        public double VmAileron
        {
            get
            {
                return this.aileron;
            }
            set
            {
                this.aileron = value;
                this.model.setAileron(this.aileron);
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