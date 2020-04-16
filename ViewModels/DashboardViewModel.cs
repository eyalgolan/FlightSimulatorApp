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

        public String VmVerticalSpeed
        {
            get
            {
                return this.model.VerticalSpeed;
            }
        }

        public String VmGroundSpeed
        {
            get
            {
                return this.model.GroundSpeed;
            }
        }

        public String VmHeading
        {
            get
            {
                return this.model.Heading;
            }
        }

        public String VmAltimeter
        {
            get
            {
                return this.model.Altimeter;
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
                return this.model.Altitude;
            }
        }

        public String VmAirSpeed
        {
            get
            {
                return this.model.AirSpeed;
            }
        }

        public String VmVerticalSpeedColor
        {
            get
            {
                return this.model.VerticalSpeedColor;
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

        public String VmAltimeterColor
        {
            get
            {
                return this.model.AltimeterColor;
            }
        }

        public String VmPitchColor
        {
            get
            {
                return this.model.PitchColor;
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
