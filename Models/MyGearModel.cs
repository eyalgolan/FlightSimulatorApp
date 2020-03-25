﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Models
{
    class MyGearModel : IGearModel
    {

        ITelnetClient tc;
        private string flightData;
        public String FlightData
        {
            set
            {
                flightData = value;
                NotifyPropertyChanged("FlightData");
            }
            get { return FlightData; }
        }

        public MyGearModel(ITelnetClient tc)
        {
            this.tc = tc;
        }
        public void connect(string ip, int port)
        {
            tc.connect(ip, port);
        }
        public void setAileron(double val)
        {
            tc.write("set /controls/flight/aileron" + val+ "\n");
        }
        public void setElevator(double val)
        {
            tc.write("set /controls/flight/elevator" + val + "\n");
        }
        public void setRudder(double val)
        {
            tc.write("set /controls/flight/rudder" + val + "\n");
        }
        
        public void setThrottle(double val)
        {

            tc.write("set/controls/engines/current-engine/throttle" + val+"\n");
        }
        public void sendGearData(double elevator, double rudder)
        {
            Console.WriteLine("11111111111111111111111111111111111111111111111");

            Console.WriteLine(rudder);
            Console.WriteLine(elevator);
            Console.WriteLine("11111111111111111111111111111111111111111111111");

            setRudder(rudder);
            setElevator(elevator);
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
