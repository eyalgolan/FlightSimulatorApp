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
        private bool isRecievingData;

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
            this.isRecievingData = true;
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
            new Thread(async delegate ()
            {
                    while (true)
                    {
                    await tc.write("get /position/latitude-deg \n");
                    double recivedLatitude;
                    Task<string> get_latitude = tc.read();
                    string input_latitude = await get_latitude;
                    bool result = double.TryParse(input_latitude, out recivedLatitude);
                    if (result)
                    {
                        if ((recivedLatitude <= 90) && (recivedLatitude >= -90))
                        {
                            latitude = input_latitude;
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
                    await tc.write("get /position/longitude-deg \n");
                    Task<string> get_longtitude = tc.read();
                    string input_longtitude = await get_longtitude;
                    result = double.TryParse(input_longtitude, out recievedLongitude);
                    if (result)
                    {
                        if ((recievedLongitude <= 180) && (recievedLongitude >= -180))
                        {
                            Longitude = input_longtitude;
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
