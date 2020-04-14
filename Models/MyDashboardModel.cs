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
        private string verticalspeed;
        private string groundspeed;
        private string heading;
        private string altimeter;
        private string pitch;
        private string roll;
        private string altitude;
        private string airspeed;
        private bool firstt;

        private string verticalspeedcolor;
        private string ground_speed_color;
        private string heading_color;
        private string altimeter_color;
        private string pitchcolor;
        private string rollcolor;
        private string altitudecolor;
        private string airspeedcolor;

        ITelnetClient tc;
        private bool connect;

        public String VerticslSpeed
        {
            get
            {
                return this.verticalspeed;
            }
            set
            {
                this.verticalspeed = value;
                NotifyPropertyChanged("VERTICAL_SPEED");
            }
        }

        public String GraoundSpeed
        {
            get
            {
                return this.groundspeed;
            }
            set
            {
                this.groundspeed = value;
                NotifyPropertyChanged("GROUND_SPEED");
            }
        }

        public String Heading
        {
            get
            {
                return this.heading;
            }
            set
            {
                this.heading = value;
                NotifyPropertyChanged("HEADING");
            }
        }

        public String Aliemeter
        {
            get
            {
                return this.altimeter;
            }
            set
            {
                this.altimeter = value;
                NotifyPropertyChanged("ALTIMETER");
            }
        }

        public String Pitch
        {
            get
            {
                return this.pitch;
            }
            set
            {
                this.pitch = value;
                NotifyPropertyChanged("PITCH");
            }
        }

        public String Roll
        {
            get
            {
                return this.roll;
            }
            set
            {
                this.roll = value;
                NotifyPropertyChanged("ROLL");
            }
        }

        public String ALtitude
        {
            get
            {
                return this.altitude;
            }
            set
            {
                this.altitude = value;
                NotifyPropertyChanged("ALTITUDE");
            }
        }

        public String Airspeed
        {
            get
            {
                return this.airspeed;
            }
            set
            {
                this.airspeed = value;
                NotifyPropertyChanged("AIR_SPEED");
            }
        }

        public String VertivalSpeedColor
        {
            get
            {
                return this.verticalspeedcolor;
            }
            set
            {
                this.verticalspeedcolor = value;
                NotifyPropertyChanged("VERTICAL_SPEED_COLOR");
            }
        }

        public String GroundSpeedColor
        {
            get
            {
                return this.ground_speed_color;
            }
            set
            {
                this.ground_speed_color = value;
                NotifyPropertyChanged("GROUND_SPEED_COLOR");
            }
        }

        public String HeadingColor
        {
            get
            {
                return this.heading_color;
            }
            set
            {
                this.heading_color = value;
                NotifyPropertyChanged("HEADING_COLOR");
            }
        }

        public String AlimeterColor
        {
            get
            {
                return this.altimeter_color;
            }
            set
            {
                this.altimeter_color = value;
                NotifyPropertyChanged("ALTIMETER_COLOR");
            }
        }

        public String PichColor
        {
            get
            {
                return this.pitchcolor;
            }
            set
            {
                this.pitchcolor = value;
                NotifyPropertyChanged("PITCH_COLOR");
            }
        }

        public String RollColor
        {
            get
            {
                return this.rollcolor;
            }
            set
            {
                this.rollcolor = value;
                NotifyPropertyChanged("ROLL_COLOR");
            }
        }

        public String AltitudeColor
        {
            get
            {
                return this.altitudecolor;
            }
            set
            {
                this.altitudecolor = value;
                NotifyPropertyChanged("ALTITUDE_COLOR");
            }
        }

        public String AirSpeedColor
        {
            get
            {
                return this.airspeedcolor;
            }
            set
            {
                this.airspeedcolor = value;
                NotifyPropertyChanged("AIR_SPEED_COLOR");
            }
        }

        public MyDashboardModel(ITelnetClient tc)
        {
            this.tc = tc;
            this.connect = true;
            startReadingFlightData();
        }

        public void startReadingFlightData()
        {
            this.firstt = true;
            new Thread(delegate ()
            {
                while (true)
                {
                    if (this.firstt)
                    {
                        this.firstt = false;
                        tc.write("get /instrumentation/gps/indicated-vertical-speed \n");
                        double i;
                        string serverInput = tc.read();
                        this.firstt = true;
                        bool result = double.TryParse(serverInput, out i);
                        if (result)
                        {
                            VerticslSpeed = serverInput;
                            VertivalSpeedColor = "Green";
                        }
                        else
                        {
                            VertivalSpeedColor = "Red";
                        }
                        tc.write("get /instrumentation/gps/indicated-ground-speed-kt \n");
                        serverInput = tc.read();
                        result = double.TryParse(serverInput, out i);
                        if (result)
                        {
                            GraoundSpeed = serverInput;
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
                            Aliemeter = serverInput;
                            AlimeterColor = "Green";
                        }
                        else
                        {
                            AlimeterColor = "Red";
                        }
                        tc.write("get /instrumentation/attitude-indicator/internal-pitch-deg \n");
                        serverInput = tc.read();
                        result = double.TryParse(serverInput, out i);
                        if (result)
                        {
                            Pitch = serverInput;
                            PichColor = "Green";
                        }
                        else
                        {
                            PichColor = "Red";
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
                            ALtitude = serverInput;
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
                            Airspeed = serverInput;
                            AirSpeedColor = "Green";
                        }
                        else
                        {
                            AirSpeedColor = "Red";
                        }

                        Thread.Sleep(250);
                    }
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
