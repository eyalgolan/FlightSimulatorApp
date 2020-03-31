﻿using System;
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

        ITelnetClient tc;
        private bool connect;
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
        public MyDashboardModel(ITelnetClient tc)
        {
            this.tc = tc;
            this.connect = true;
            startReadingFlightData();
        }
        public void startReadingFlightData()
        {
            new Thread(delegate ()
            {
                while (connect)
                {
                    tc.write("get /instrumentation/gps/indicated-vertical-speed \n");
                    double i;
                    string testt = tc.read();
                    bool result = double.TryParse(testt, out i);
                    if (result)
                    {
                        VERTICAL_SPEED = testt;
                    }
                    else
                    {
                        // eror
                    }
                    tc.write("get /instrumentation/gps/indicated-ground-speed-kt \n");
                     testt = tc.read();
                     result = double.TryParse(testt, out i);
                    if (result)
                    {
                        GROUND_SPEED = testt;
                    }
                    else
                    {
                        // eror
                    }
                    tc.write("get /instrumentation/heading-indicator/indicated-heading-deg \n");
                    testt = tc.read();
                    result = double.TryParse(testt, out i);
                    if (result)
                    {
                        HEADING = testt;
                    }
                    else
                    {
                        // eror
                    }
                    tc.write("get /instrumentation/altimeter/indicated-altitude-ft \n");
                    testt = tc.read();
                    result = double.TryParse(testt, out i);
                    if (result)
                    {
                        ALTIMETER = testt;
                    }
                    else
                    {
                        // eror
                    }
                    tc.write("get /instrumentation/attitude-indicator/internal-pitch-deg \n");
                    testt = tc.read();
                    result = double.TryParse(testt, out i);
                    if (result)
                    {
                        PITCH = testt;
                    }
                    else
                    {
                        // eror
                    }
                    tc.write("get /instrumentation/attitude-indicator/internal-roll-deg \n");
                    testt = tc.read();
                    result = double.TryParse(testt, out i);
                    if (result)
                    {
                        ROLL = testt;
                    }
                    else
                    {
                        // eror
                    }
                    tc.write("get /instrumentation/gps/indicated-altitude-ft \n");
                    testt = tc.read();
                    result = double.TryParse(testt, out i);
                    if (result)
                    {
                        ALTITUDE = testt;
                    }
                    else
                    {
                        // eror
                    }
                    tc.write("get /instrumentation/airspeed-indicator/indicated-speed-kt \n");
                    testt = tc.read();
                    result = double.TryParse(testt, out i);
                    if (result)
                    {
                        AIR_SPEED = testt;
                    }
                    else
                    {
                        // eror
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
