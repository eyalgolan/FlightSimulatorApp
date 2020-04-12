using System;
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
        private double throttle;
        private double rudder;
        private double elevator;
        private double aileron;
        public String FlightData
        {
            set
            {
                flightData = value;
                NotifyPropertyChanged("FlightData");
            }
            get { return FlightData; }
        }

        public double Throttle
        {
            get { return throttle; }
            set
            {
                if (tc.areconected())
                {

                    setThrottle(value);
                    this.throttle = value;
                    NotifyPropertyChanged("throttle");
                }
            }
        }
        public double Rudder
        {
            get { return rudder; }
            set
            {
                if (tc.areconected())
                {

                    setRudder(value);
                    this.rudder = value;
                    NotifyPropertyChanged("rudder");
                }

            }
        }
        public double Elevator
        {
            get
            {
                return elevator;
            }
            set
            {
                if (tc.areconected())
                {

                    setElevator(value);
                    this.elevator = value;
                    NotifyPropertyChanged("elevator");
                }

            }
        }
        public double Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                if (tc.areconected())
                {

                    setAileron(value);
                    this.aileron = value;
                    NotifyPropertyChanged("aileron");
                }
            }
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
            if (tc.areconected())
            {

                tc.write("set /controls/flight/aileron" + " " + val + "\n");
                tc.read();
            }

        }
        public void setElevator(double val)
        {
            if (tc.areconected())
            {

                tc.write("set /controls/flight/elevator" + " " + val + "\n");
                tc.read();
            }
        }
        public void setRudder(double val)
        {
            if (tc.areconected())
            {

                tc.write("set /controls/flight/rudder" + " " + val + "\n");
                tc.read();
            }
        }

        public void setThrottle(double val)
        {
            if (tc.areconected())
            {

                tc.write("set /controls/engines/current-engine/throttle" + " " + val + "\n");
                tc.read();
            }
        }
        public void sendGearData(double elevator, double rudder)
        {
            if (tc.areconected())
            {
                setRudder(rudder);
                setElevator(elevator);
            }
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

        public void aircjange(double newValue)
        {
            if (tc.areconected())
            {
                setAileron(newValue);
            }
        }

        public void troutlechange(double newValue)
        {
            if (tc.areconected())
            {
                setThrottle(newValue);
            }
        }
    }
}
