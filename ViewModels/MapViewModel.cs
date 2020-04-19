using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlightSimulatorApp.Models;
using Microsoft.Maps.MapControl.WPF;

namespace FlightSimulatorApp.ViewModels
{
    public class MapViewModel : INotifyPropertyChanged
    {
        IMapModel model;
        private LocationCollection planePath;
        private Location newPath;
        public MapViewModel(IMapModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
              {
                  NotifyPropertyChanged("Vm" + e.PropertyName);
              };
            planePath = new LocationCollection();
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
        //Properties

        //Property responsible for the last added location of the plane
        public Location VmNewPath
        {
            get
            {
                return this.newPath;
            }
            set
            {
                this.newPath = value;
                VmPlanePath.Add(VmNewPath);
            }
        }

        //Property responsible for the plane's path
        public LocationCollection VmPlanePath
        {
            get
            {
                return this.planePath;
            }
        }

        //Property responsible for relaying the plane's latitude
        public String VmLatitude
        {
            get { return model.Latitude; }
        }
        //Property responsible for relaying the plane's longtitude
        public String VmLongitude
        {
            get { return model.Longitude; }
        }
        //Property responsible for relaying latitude errors
        public String VmLatitudeError
        {
            get
            {
                return this.model.LatitudeError;
            }
        }
        //Property responsible for relaying the longtitude errors
        public String VmLongitudeError
        {
            get
            {
                return this.model.LongitudeError;
            }
        }
        //Property responsible for relaying the plane's location
        public String VmFlightData
        {
            get 
            {
                VmNewPath = new Location(Convert.ToDouble(VmLatitude),Convert.ToDouble(VmLongitude));
                return model.FlightData; 
            }
        }
    }
}
