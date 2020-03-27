using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maps.MapControl.WPF;

namespace FlightSimulatorApp.Models
{
    class MyMapModel : IMapModel
    {
        ITelnetClient tc;
        private string latitude;
        private string longitude;
        private Location planeLocation;
        private bool connect;

        public MyMapModel(ITelnetClient tc)
        {
            this.tc = tc;
            this.latitude = "0";
            this.longitude = "0";
            planeLocation = new Location(0, 0);
            this.connect = true;
            startReadingFlightData();
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
        public Location FlightData
        {
            set
            {
                if (planeLocation != value)
                {
                    planeLocation = value;
                    NotifyPropertyChanged("FlightData");
                }
            }
            get
            {
                return planeLocation;
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
                while (connect)
                {
                    
                  

                    tc.write("get /position/latitude-deg \n");
                    Latitude = tc.read();
                    tc.write("get /position/longitude-deg\n");
                    Longitude = tc.read();
                    FlightData.Longitude = Convert.ToDouble(Longitude);
                    FlightData.Latitude = Convert.ToDouble(Latitude);
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
