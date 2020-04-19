using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;

namespace FlightSimulatorApp.Models
{
    class MyDashboardModel : IDashboardModel
    {
        private string verticalSpeed;
        private string groundSpeed;
        private string heading;
        private string altimeter;
        private string pitch;
        private string roll;
        private string altitude;
        private string airSpeed;

        private string verticalspeedcolor;
        private string groundSpeedColor;
        private string headingColor;
        private string altimeterColor;
        private string pitchColor;
        private string rollColor;
        private string altitudeColor;
        private string airSpeedColor;

        ITelnetClient tc;

        //Properties

        //Property responsible for VerticalSpeed
        public String VerticalSpeed
        {
            get
            {
                return this.verticalSpeed;
            }
            set
            {
                this.verticalSpeed = value;
                NotifyPropertyChanged("VerticalSpeed");
            }
        }
        //Property responsible for GroundSpeed
        public String GroundSpeed
        {
            get
            {
                return this.groundSpeed;
            }
            set
            {
                this.groundSpeed = value;
                NotifyPropertyChanged("GroundSpeed");
            }
        }
        //Property responsible for Heading
        public String Heading
        {
            get
            {
                return this.heading;
            }
            set
            {
                this.heading = value;
                NotifyPropertyChanged("Heading");
            }
        }
        //Property responsible for Altimeter
        public String Altimeter
        {
            get
            {
                return this.altimeter;
            }
            set
            {
                this.altimeter = value;
                NotifyPropertyChanged("Altimeter");
            }
        }
        //Property responsible for Pitch
        public String Pitch
        {
            get
            {
                return this.pitch;
            }
            set
            {
                this.pitch = value;
                NotifyPropertyChanged("Pitch");
            }
        }
        //Property responsible for Roll
        public String Roll
        {
            get
            {
                return this.roll;
            }
            set
            {
                this.roll = value;
                NotifyPropertyChanged("Roll");
            }
        }
        //Property responsible for Altitude
        public String Altitude
        {
            get
            {
                return this.altitude;
            }
            set
            {
                this.altitude = value;
                NotifyPropertyChanged("Altitude");
            }
        }
        //Property responsible for AirSpeed
        public String AirSpeed
        {
            get
            {
                return this.airSpeed;
            }
            set
            {
                this.airSpeed = value;
                NotifyPropertyChanged("AirSpeed");
            }
        }
        //Property responsible for VerticalSpeedColor
        public String VerticalSpeedColor
        {
            get
            {
                return this.verticalspeedcolor;
            }
            set
            {
                this.verticalspeedcolor = value;
                NotifyPropertyChanged("VerticalSpeedColor");
            }
        }
        //Property responsible for GroundSpeedColor
        public String GroundSpeedColor
        {
            get
            {
                return this.groundSpeedColor;
            }
            set
            {
                this.groundSpeedColor = value;
                NotifyPropertyChanged("GroundSpeedColor");
            }
        }
        //Property responsible for HeadingColor
        public String HeadingColor
        {
            get
            {
                return this.headingColor;
            }
            set
            {
                this.headingColor = value;
                NotifyPropertyChanged("HeadingColor");
            }
        }
        //Property responsible for AltimeterColor
        public String AltimeterColor
        {
            get
            {
                return this.altimeterColor;
            }
            set
            {
                this.altimeterColor = value;
                NotifyPropertyChanged("AltimeterColor");
            }
        }
        //Property responsible for PitchColor
        public String PitchColor
        {
            get
            {
                return this.pitchColor;
            }
            set
            {
                this.pitchColor = value;
                NotifyPropertyChanged("PitchColor");
            }
        }
        //Property responsible for RollColor
        public String RollColor
        {
            get
            {
                return this.rollColor;
            }
            set
            {
                this.rollColor = value;
                NotifyPropertyChanged("RollColor");
            }
        }
        //Property responsible for AltitudeColor
        public String AltitudeColor
        {
            get
            {
                return this.altitudeColor;
            }
            set
            {
                this.altitudeColor = value;
                NotifyPropertyChanged("AltitudeColor");
            }
        }
        //Property responsible for AirSpeedColor
        public String AirSpeedColor
        {
            get
            {
                return this.airSpeedColor;
            }
            set
            {
                this.airSpeedColor = value;
                NotifyPropertyChanged("AirSpeedColor");
            }
        }

        public MyDashboardModel(ITelnetClient tc)
        {
            this.tc = tc;
            startReadingFlightData();
        }

        // function running a thread that asks for information about the plane's different values, 4 times a second
        public void startReadingFlightData()
        {
            new Thread(delegate ()
            {
                while (true)
                {
                        tc.write("get /instrumentation/gps/indicated-vertical-speed \n");
                        double i;
                        string serverInput = tc.read();
                        bool result = double.TryParse(serverInput, out i);
                        if (result)
                        {
                            VerticalSpeed = serverInput;
                            VerticalSpeedColor = "Green";
                        }
                        else
                        {
                            VerticalSpeedColor = "Red";
                        }
                        tc.write("get /instrumentation/gps/indicated-ground-speed-kt \n");
                        serverInput = tc.read();
                        result = double.TryParse(serverInput, out i);
                        if (result)
                        {
                            GroundSpeed = serverInput;
                            GroundSpeedColor = "Green";
                        }
                        else
                        {
                            GroundSpeedColor = "Red";
                        }
                        tc.write("get /instrumentation/heading-indicator/indicated-heading-deg \n");
                        serverInput = tc.read();
                        result = double.TryParse(serverInput, out i);
                        if (result)
                        {
                            Heading = serverInput;
                            HeadingColor = "Green";
                        }
                        else
                        {
                            HeadingColor = "Red";
                        }
                        tc.write("get /instrumentation/altimeter/indicated-altitude-ft \n");
                        serverInput = tc.read();
                        result = double.TryParse(serverInput, out i);
                        if (result)
                        {
                            Altimeter = serverInput;
                            AltimeterColor = "Green";
                        }
                        else
                        {
                            AltimeterColor = "Red";
                        }
                        tc.write("get /instrumentation/attitude-indicator/internal-pitch-deg \n");
                        serverInput = tc.read();
                        result = double.TryParse(serverInput, out i);
                        if (result)
                        {
                            Pitch = serverInput;
                            PitchColor = "Green";
                        }
                        else
                        {
                            PitchColor = "Red";
                        }
                        tc.write("get /instrumentation/attitude-indicator/internal-roll-deg \n");
                        serverInput = tc.read();
                        result = double.TryParse(serverInput, out i);
                        if (result)
                        {
                            Roll = serverInput;
                            RollColor = "Green";
                        }
                        else
                        {
                            RollColor = "Red";
                        }
                        tc.write("get /instrumentation/gps/indicated-altitude-ft \n");
                        serverInput = tc.read();
                        result = double.TryParse(serverInput, out i);
                        if (result)
                        {
                            Altitude = serverInput;
                            AltitudeColor = "Green";
                        }
                        else
                        {
                            AltitudeColor = "Red";
                        }
                        tc.write("get /instrumentation/airspeed-indicator/indicated-speed-kt \n");
                        serverInput = tc.read();
                        result = double.TryParse(serverInput, out i);
                        if (result)
                        {
                            AirSpeed = serverInput;
                            AirSpeedColor = "Green";
                        }
                        else
                        {
                            AirSpeedColor = "Red";
                        }

                        Thread.Sleep(250);
                    }
            }).Start();
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
