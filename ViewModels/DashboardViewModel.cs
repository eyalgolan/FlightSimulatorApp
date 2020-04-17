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

        //Property responsible for relaying the VerticalSpeed
        public String VmVerticalSpeed
        {
            get
            {
                return this.model.VerticalSpeed;
            }
        }
        //Property responsible for relaying the GroundSpeed
        public String VmGroundSpeed
        {
            get
            {
                return this.model.GroundSpeed;
            }
        }
        //Property responsible for relaying the Heading
        public String VmHeading
        {
            get
            {
                return this.model.Heading;
            }
        }
        //Property responsible for relaying the Altimeter
        public String VmAltimeter
        {
            get
            {
                return this.model.Altimeter;
            }
        }
        //Property responsible for relaying the Pitch
        public String VmPitch
        {
            get
            {
                return this.model.Pitch;
            }
        }
        //Property responsible for relaying the Roll
        public String VmRoll
        {
            get
            {
                return this.model.Roll;
            }
        }
        //Property responsible for relaying the Altitude
        public String VmAltitude
        {
            get
            {
                return this.model.Altitude;
            }
        }
        //Property responsible for relaying the AirSpeed
        public String VmAirSpeed
        {
            get
            {
                return this.model.AirSpeed;
            }
        }
        //Property responsible for relaying the VerticalSpeedColor
        public String VmVerticalSpeedColor
        {
            get
            {
                return this.model.VerticalSpeedColor;
            }
        }
        //Property responsible for relaying the GroundSpeedColor
        public String VmGroundSpeedColor
        {
            get
            {
                return this.model.GroundSpeedColor;
            }
        }
        //Property responsible for relaying the HeadingColor
        public String VmHeadingColor
        {
            get
            {
                return this.model.HeadingColor;
            }
        }
        //Property responsible for relaying the AltimeterColor
        public String VmAltimeterColor
        {
            get
            {
                return this.model.AltimeterColor;
            }
        }
        //Property responsible for relaying the PitchColor
        public String VmPitchColor
        {
            get
            {
                return this.model.PitchColor;
            }
        }
        //Property responsible for relaying the RollColor
        public String VmRollColor
        {
            get
            {
                return this.model.RollColor;
            }
        }
        //Property responsible for relaying the AltitudeColor
        public String VmAltitudeColor
        {
            get
            {
                return this.model.AltitudeColor;
            }
        }
        //Property responsible for relaying the AirSpeedColor
        public String VmAirSpeedColor
        {
            get
            {
                return this.model.AirSpeedColor;
            }
        }
    }
}
