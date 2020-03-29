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
            tc.write("set /controls/flight/aileron"+" " + val+ "\n");
            string test0 = tc.read();

        }
        public void setElevator(double val)
        {
            tc.write("set /controls/flight/elevator" + " " + val + "\n");
        //    tc.write("get /controls/flight/elevator\n");
            string test2 = tc.read();
           


        }
        public void setRudder(double val)
        {

            tc.write("set /controls/flight/rudder" + " " + val + "\n");
      //      tc.write("get /controls/flight/rudder\n");
            string test1 = tc.read();




        }

        public void setThrottle(double val)
        {

            tc.write("set /controls/engines/current-engine/throttle"+" " + val+"\n");
            string test3 = tc.read();

        }
        public void sendGearData(double elevator, double rudder)
        {

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

        public void aircjange(double newValue)
        {
            setAileron(newValue);
        }

        public void troutlechange(double newValue)
        {
            setThrottle(newValue);
        }
    }
}
