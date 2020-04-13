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
        private String oldlat;
        private String oldlong;
        private string latitudeError;
        private string longitudeError;
        private string planeLocation;
        private bool connect;

        public MyMapModel(ITelnetClient tc)
        {
            this.tc = tc;
            Latitude = "32.006833306";
            Longitude = "34.885329792";
            LatitudeError = "";
            LongitudeError = "";
            this.oldlat = Latitude;
            this.oldlong = Longitude;
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
        public String FlightData
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

        public String LatitudeError
        {
            get
            {
                return this.latitudeError;
            }
            set
            {
                this.latitudeError = value;
                NotifyPropertyChanged("LatitudeError");
            }
        }
        public String LongitudeError
        {
            get
            {
                return this.longitudeError;
            }
            set
            {
                this.longitudeError = value;
                NotifyPropertyChanged("LongitudeError");
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
                    if (String.Equals(tc.IsConnected, "Connected"))
                    {
                        tc.write("get /position/latitude-deg \n");
                        double recivedLatitude;
                        string serverInput = tc.read();
                        bool result = double.TryParse(serverInput, out recivedLatitude);
                        if (result)
                        {
                            if ((recivedLatitude <= 90) && (recivedLatitude >= -90))
                            {
                                latitude = serverInput;
                                oldlat = latitude;
                                LatitudeError = "";
                            }
                            else
                            {
                                latitude = oldlat;
                                LatitudeError = "Bad latitude recieved, showing last correct atitude";
                            }
                        }
                        else
                        {
                            // eror
                        }
                        double recievedLongitude;
                        tc.write("get /position/longitude-deg \n");
                        serverInput = tc.read();
                        result = double.TryParse(serverInput, out recievedLongitude);
                        if (result)
                        {
                            if ((recievedLongitude <= 180) && (recievedLongitude >= -180))
                            {
                                Longitude = serverInput;
                                oldlong = Longitude;
                                LongitudeError = "";
                            }
                            else
                            {
                                Longitude = oldlong;
                                LongitudeError = "Bad longitude recieved, showing last correct longitude";
                            }
                        }
                        else
                        {
                            // eror
                        }
                        FlightData = Latitude + "," + Longitude;
                        Thread.Sleep(250);
                    }
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
