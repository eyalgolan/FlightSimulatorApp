using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlightSimulatorApp.Models;

namespace FlightSimulatorApp.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        IDashboardModel model;

        public DashboardViewModel(IDashboardModel model)
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

        public String VmVerticalSpeed
        {
            get
            {
                return this.model.VerticslSpeed;
            }
        }

        public String VmGroundSpeed
        {
            get
            {
                return this.model.GraoundSpeed;
            }
        }

        public String VmHeading
        {
            get
            {
                return this.model.Heading;
            }
        }

        public String Vmalimeter
        {
            get
            {
                return this.model.Aliemeter;
            }
        }

        public String VmPitch
        {
            get
            {
                return this.model.Pitch;
            }
        }

        public String VmRoll
        {
            get
            {
                return this.model.Roll;
            }
        }

        public String VmAltitude
        {
            get
            {
                return this.model.ALtitude;
            }
        }

        public String VmAirSpeed
        {
            get
            {
                return this.model.Airspeed;
            }
        }

        public String VmVertcialSpeedColor
        {
            get
            {
                return this.model.VertivalSpeedColor;
            }
        }

        public String VmGroundSpeedColor
        {
            get
            {
                return this.model.GroundSpeedColor;
            }
        }

        public String VmHeadingColor
        {
            get
            {
                return this.model.HeadingColor;
            }
        }

        public String VmAlimeterColor
        {
            get
            {
                return this.model.AlimeterColor;
            }
        }

        public String VmPitchColor
        {
            get
            {
                return this.model.PichColor;
            }
        }

        public String VmRollColor
        {
            get
            {
                return this.model.RollColor;
            }
        }

        public String VmAltitudeColor
        {
            get
            {
                return this.model.AltitudeColor;
            }
        }

        public String VmAirSpeedColor
        {
            get
            {
                return this.model.AirSpeedColor;
            }
        }
    }
}
