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
        private string vertical_speed;
        private string ground_speed;
        private string heading;
        private string altimeter;
        private string pitch;
        private string roll;
        private string altitude;
        private string air_speed;

        private string vertical_speed_color;
        private string ground_speed_color;
        private string heading_color;
        private string altimeter_color;
        private string pitch_color;
        private string roll_color;
        private string altitude_color;
        private string air_speed_color;

        ITelnetClient tc;
        private bool connect;
        private bool isRecievingData;

        public String VERTICAL_SPEED
        {
            get
            {
                return this.vertical_speed;
            }
            set
            {
                this.vertical_speed = value;
                NotifyPropertyChanged("VERTICAL_SPEED");
            }
        }

        public String GROUND_SPEED
        {
            get
            {
                return this.ground_speed;
            }
            set
            {
                this.ground_speed = value;
                NotifyPropertyChanged("GROUND_SPEED");
            }
        }

        public String HEADING
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

        public String ALTIMETER
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

        public String PITCH
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

        public String ROLL
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

        public String ALTITUDE
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

        public String AIR_SPEED
        {
            get
            {
                return this.air_speed;
            }
            set
            {
                this.air_speed = value;
                NotifyPropertyChanged("AIR_SPEED");
            }
        }

        public String VERTICAL_SPEED_COLOR
        {
            get
            {
                return this.vertical_speed_color;
            }
            set
            {
                this.vertical_speed_color = value;
                NotifyPropertyChanged("VERTICAL_SPEED_COLOR");
            }
        }

        public String GROUND_SPEED_COLOR
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

        public String HEADING_COLOR
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

        public String ALTIMETER_COLOR
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

        public String PITCH_COLOR
        {
            get
            {
                return this.pitch_color;
            }
            set
            {
                this.pitch_color = value;
                NotifyPropertyChanged("PITCH_COLOR");
            }
        }

        public String ROLL_COLOR
        {
            get
            {
                return this.roll_color;
            }
            set
            {
                this.roll_color = value;
                NotifyPropertyChanged("ROLL_COLOR");
            }
        }

        public String ALTITUDE_COLOR
        {
            get
            {
                return this.altitude_color;
            }
            set
            {
                this.altitude_color = value;
                NotifyPropertyChanged("ALTITUDE_COLOR");
            }
        }

        public String AIR_SPEED_COLOR
        {
            get
            {
                return this.air_speed_color;
            }
            set
            {
                this.air_speed_color = value;
                NotifyPropertyChanged("AIR_SPEED_COLOR");
            }
        }

        public MyDashboardModel(ITelnetClient tc)
        {
            this.tc = tc;
            this.connect = true;
            this.isRecievingData = true;
        startReadingFlightData();
        }

        public void startReadingFlightData()
        {
            new Thread(async delegate ()
            {
                while (true)
                {
                    tc.write("get /instrumentation/gps/indicated-vertical-speed \n");
                    double i;
                    Task<string> get_vertical_sync = tc.read();
                    string vertical_speed = await get_vertical_sync;
                    bool result = double.TryParse(vertical_speed, out i);
                    if (result)
                    {
                        VERTICAL_SPEED = vertical_speed;
                        VERTICAL_SPEED_COLOR = "Green";
                    }
                    else
                    {
                        VERTICAL_SPEED_COLOR = "Red";
                    }
                    tc.write("get /instrumentation/gps/indicated-ground-speed-kt \n");
                    Task<string> get_ground_speed = tc.read();
                    string ground_speed = await get_ground_speed;
                    result = double.TryParse(ground_speed, out i);
                    if (result)
                    {
                        GROUND_SPEED = ground_speed;
                        GROUND_SPEED_COLOR = "Green";
                    }
                    else
                    {
                        GROUND_SPEED_COLOR = "Red";
                    }
                    tc.write("get /instrumentation/heading-indicator/indicated-heading-deg \n");
                    Task<string> get_heading = tc.read();
                    string heading = await get_heading;
                    result = double.TryParse(heading, out i);
                    if (result)
                    {
                        HEADING = heading;
                        HEADING_COLOR = "Green";
                    }
                    else
                    {
                        HEADING_COLOR = "Red";
                    }
                    tc.write("get /instrumentation/altimeter/indicated-altitude-ft \n");
                    Task<string> get_altimeter = tc.read();
                    string altimeter = await get_altimeter;
                    result = double.TryParse(altimeter, out i);
                    if (result)
                    {
                        ALTIMETER = altimeter;
                        ALTIMETER_COLOR = "Green";
                    }
                    else
                    {
                        ALTIMETER_COLOR = "Red";
                    }
                    tc.write("get /instrumentation/attitude-indicator/internal-pitch-deg \n");
                    Task<string> get_pitch = tc.read();
                    string pitch = await get_pitch;
                    result = double.TryParse(pitch, out i);
                    if (result)
                    {
                        PITCH = pitch;
                        PITCH_COLOR = "Green";
                    }
                    else
                    {
                        PITCH_COLOR = "Red";
                    }
                    tc.write("get /instrumentation/attitude-indicator/internal-roll-deg \n");
                    Task<string> get_roll = tc.read();
                    string roll = await get_roll;
                    result = double.TryParse(roll, out i);
                    if (result)
                    {
                        ROLL = roll;
                        ROLL_COLOR = "Green";
                    }
                    else
                    {
                        ROLL_COLOR = "Red";
                    }
                    tc.write("get /instrumentation/gps/indicated-altitude-ft \n");
                    Task<string> get_altitude = tc.read();
                    string altitude = await get_altitude;
                    result = double.TryParse(altitude, out i);
                    if (result)
                    {
                        ALTITUDE = altitude;
                        ALTITUDE_COLOR = "Green";
                    }
                    else
                    {
                        ALTITUDE_COLOR = "Red";
                    }
                    tc.write("get /instrumentation/airspeed-indicator/indicated-speed-kt \n");
                    Task<string> get_air_speed = tc.read();
                    string air_speed = await get_air_speed;
                    result = double.TryParse(air_speed, out i);
                    if (result)
                    {
                        AIR_SPEED = air_speed;
                        AIR_SPEED_COLOR = "Green";
                    }
                    else
                    {
                        AIR_SPEED_COLOR = "Red";
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
