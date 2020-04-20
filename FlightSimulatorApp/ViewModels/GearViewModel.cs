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
        // varible sets 
        IGearModel model;
        private double rudder;
        private double elevator;
        private double aileron;
        private double throttle;

        public GearViewModel(IGearModel model)
        {
            this.model = model;
        }

        //Properties

        //property responsible for relaying the rudder
        public double VmRudder
        {
            get
            {
                return this.rudder;
            }
            set
            {
                this.rudder = value;
                this.model.SetRudder(this.rudder);
            }
        }

        //property responsible for relaying the elevator
        public double VmElevator
        {
            get
            {
                return this.elevator;
            }
            set
            {
                this.elevator = value;
                this.model.SetElevator(this.elevator);
            }
        }

        //property responsible for relaying the throttle
        public double VmThrottle
        {
            get
            {
                return this.throttle;
            }
            set
            {
                this.throttle = value;
                this.model.SetThrottle(this.throttle);
            }
        }

        //property responsible for relaying the aileron
        public double VmAileron
        {
            get
            {
                return this.aileron;
            }
            set
            {
                this.aileron = value;
                this.model.SetAileron(this.aileron);
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
    }
}