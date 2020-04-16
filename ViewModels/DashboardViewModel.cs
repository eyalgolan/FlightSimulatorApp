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

        public String VM_VerticalSpeed
        {
            get
            {
                return this.model.VerticslSpeed;
            }
        }

        public String VM_GroundSpeed
        {
            get
            {
                return this.model.GraoundSpeed;
            }
        }

        public String VM_Heading
        {
            get
            {
                return this.model.Heading;
            }
        }

        public String VM_Alimeter
        {
            get
            {
                return this.model.Aliemeter;
            }
        }

        public String VM_Pitch
        {
            get
            {
                return this.model.Pitch;
            }
        }

        public String VM_Roll
        {
            get
            {
                return this.model.Roll;
            }
        }

        public String VM_Altitude
        {
            get
            {
                return this.model.ALtitude;
            }
        }

        public String VM_AirSpeed
        {
            get
            {
                return this.model.Airspeed;
            }
        }

        public String VM_VertcialSpeedColor
        {
            get
            {
                return this.model.VertivalSpeedColor;
            }
        }

        public String VM_GroundSpeedColor
        {
            get
            {
                return this.model.GroundSpeedColor;
            }
        }

        public String VM_HeadingColor
        {
            get
            {
                return this.model.HeadingColor;
            }
        }

        public String VM_AlimeterColor
        {
            get
            {
                return this.model.AlimeterColor;
            }
        }

        public String VM_PitchColor
        {
            get
            {
                return this.model.PichColor;
            }
        }

        public String VM_RollColor
        {
            get
            {
                return this.model.RollColor;
            }
        }

        public String VM_AltitudeColor
        {
            get
            {
                return this.model.AltitudeColor;
            }
        }

        public String VM_AirSpeedColor
        {
            get
            {
                return this.model.AirSpeedColor;
            }
        }
    }
}
