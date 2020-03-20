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
        private string flightData;
        private string latitude;
        private string longitude; 
        public String FlightData
        {
            set
            {
                if(flightData != value)
                {
                    flightData = value;
                    //need to parse flightData and send it to Latitude and Longitude
                    NotifyPropertyChanged("FlightData");
                }
            }
            get { return flightData; }
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
        public string getFlightData()
        {
            return FlightData;
        }

        public void startReadingFlightData()
        {
            new Thread(delegate ()
            {
                while (true)
                {
                    FlightData = tc.read();
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
