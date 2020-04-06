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
        private double mvrudder;
        private double mvelvetor;
        private double mvaileron;
        private double mvthrottle;

        IGearModel model;

        public GearViewModel(IGearModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        public void moveGear (double elevator , double rudder)
        {
            model.sendGearData(elevator, rudder);
            
        }
        public double vm_rudder
        {
            get
            {
                return mvrudder;
            }
            set
            {
                
                mvrudder = value;
                model.Rudder = value;
            }
        }
        public double vm_elevator
        {
            get
            {
                return mvelvetor;
            }
            set
            {
                
                mvelvetor = value;
                model.Elevator = value;
            }
        }
        public double vm_throttle
        {
            get
            {
                return mvthrottle;
            }
            set
            {
              

                mvthrottle = value;
                model.Throttle = value;
            }
        }
        public double vm_aileron
        {
            get
            {
                return mvaileron;
            }
            set
            {
                mvaileron = value;
                model.Aileron = value;
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

        internal void airlonchange(double newValue)
        {
            model.aircjange(newValue);
        }

        internal void thurtelchange(double newValue)
        {
            model.troutlechange(newValue);
        }

    }
}
