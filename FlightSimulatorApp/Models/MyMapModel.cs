using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maps.MapControl.WPF;
using FlightSimulatorApp;

namespace FlightSimulatorApp.Models
{
    class MyMapModel : IMapModel
    {
        ITelnetClient tc;
        private string latitude;
        private string longitude;
        private String oldLatitude;
        private String oldLongtitude;
        private string latitudeError;
        private string longitudeError;
        private string planeLocation;

        // MyMapModel Ctor
        public MyMapModel(ITelnetClient tc)
        {
            this.tc = tc;
            Latitude = System.Configuration.ConfigurationManager.AppSettings["startLatitude"];
            Longitude = System.Configuration.ConfigurationManager.AppSettings["startLongitude"];
            LatitudeError = "";
            LongitudeError = "";
            this.oldLatitude = Latitude;
            this.oldLongtitude = Longitude;
            StartReadingFlightData();
        }

        //Properties

        //Property holding the plane's latitude
        public String Latitude
        {
            set
            {
                if (latitude != value)
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

        //Property holding the plane's longitude
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

        //Property holding the plane's location
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

        //Property holding errors regarding the plane's latitude
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

        //Property holding errors regarding the plane's longitude
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

        // function running a thread that asks for information about the plane's location 4 times a second
        public void StartReadingFlightData()
        {
            new Thread(delegate ()
            {
                while (true)
                {
                    // getting the plane's current latitude
                    tc.Write("get /position/latitude-deg \n");
                    double recivedLatitude;
                    string serverInput = tc.Read();
                    bool result = double.TryParse(serverInput, out recivedLatitude);
                    //checking if the recieved input can be parsed to double
                    if (result)
                    {
                        //checking if recieved value is in valid range
                        if (((recivedLatitude <= 90) && (recivedLatitude >= -90)) && (Math.Abs(Convert.ToDouble(recivedLatitude) - Math.Abs(Convert.ToDouble(oldLatitude))) < 2))
                        {
                            Latitude = serverInput;
                            oldLatitude = latitude;
                            LatitudeError = "";
                        }
                        // if not, showing an appropriate message
                        else
                        {
                            latitude = oldLatitude;
                            LatitudeError = "Bad latitude recieved, showing last correct atitude";
                        }
                    }
                    // if not, writing to console
                    else
                    {
                        Console.WriteLine("Map model couldn't parse Latitude from server");
                    }
                    // getting the plane's current longitude
                    double recievedLongitude;
                    tc.Write("get /position/longitude-deg \n");
                    serverInput = tc.Read();
                    result = double.TryParse(serverInput, out recievedLongitude);
                    //checking if the recieved input can be parsed to double
                    if (result)
                    {
                        //checking if recieved value is in valid range
                        if (((recievedLongitude <= 180) && (recievedLongitude >= -180)) && (Math.Abs(Convert.ToDouble(recievedLongitude)) - (Math.Abs(Convert.ToDouble(oldLongtitude))) < 2))
                        {
                            Longitude = serverInput;
                            oldLongtitude = Longitude;
                            LongitudeError = "";
                        }
                        // if not, showing an appropriate message
                        else
                        {
                            Longitude = oldLongtitude;
                            LongitudeError = "Bad longitude recieved, showing last correct longitude";
                        }
                    }
                    // if not, writing to console
                    else
                    {
                        Console.WriteLine("Map model couldn't parse Longitude from server");
                    }

                    //bringing the plane back to starting position, if the connection has terminated and the plane's location values were not set to default yet
                    if (String.Equals(tc.IsConnected, "Disconnected") && (this.Latitude != System.Configuration.ConfigurationManager.AppSettings["startLatitude"] ||
                    this.Longitude != System.Configuration.ConfigurationManager.AppSettings["startLongitude"]))
                    {
                        Latitude = System.Configuration.ConfigurationManager.AppSettings["startLatitude"];
                        Longitude = System.Configuration.ConfigurationManager.AppSettings["startLongitude"];
                        oldLatitude = System.Configuration.ConfigurationManager.AppSettings["startLatitude"];
                        oldLongtitude = System.Configuration.ConfigurationManager.AppSettings["startLongitude"];
                        latitudeError = "";
                        LongitudeError = "";
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
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
