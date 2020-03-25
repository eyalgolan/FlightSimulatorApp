using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Models
{
    class MyMapModel : IMapModel
    {
        ITelnetClient tc;
        private string latitude = "0";
        private string longitude = "0";

        public MyMapModel(ITelnetClient tc)
        {
            this.tc = tc;
        }

        public String Latitude
        {
            set
            {
                if(latitude != value)
                {
                    latitude = value;
                    NotifyPropertyChanged("Latitude");
                }
            }
            get
            {
                return latitude;
            }
        }
        public String Longitude
        {
            set
            {
                if (longitude != value)
                {
                    longitude = value;
                    NotifyPropertyChanged("Longitude");
                }
            }
            get
            {
                return longitude;
            }
        }
        public string getFlightLongitude()
        {
            return longitude;
        }
        public string getFlightLatitude()
        {
            return latitude;
        }
        public void startReadingFlightData()
        {
            new Thread(delegate ()
            {
                while (true)
                {
                    tc.write("get/position/latitude-deg\n");
                    Latitude = tc.read();
                    tc.write("get/position/longitude-deg\n");
                    Longitude = tc.read();
                    Thread.Sleep(250);
                }
            }).Start();
        }

        //INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(String propName)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
