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
            tc.write("set controls[0]/flight[0]/aileron" + val);
        }
        public void setElevator(double val)
        {
            tc.write("set controls[0]/flight[0]/elevator" + val);
        }
        public void setRudder(double val)
        {
            tc.write("set controls[0]/flight[0]/rudder" + val);
        }
        
        public void setThrottle(double val)
        {
            tc.write("set controls[0]/flight[0]/throttle" + val);
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
