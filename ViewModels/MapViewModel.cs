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

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

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
        public LocationCollection VmPlanePath
        {
            get
            {
                return this.planePath;
            }
        }
        //Properties
        public String VmLatitude
        {
            get { return model.Latitude; }
        }
        public String VmLongitude
        {
            get { return model.Longitude; }
        }
        public String VmLatitudeError
        {
            get
            {
                return this.model.LatitudeError;
            }
        }
        public String VmLongitudeError
        {
            get
            {
                return this.model.LongitudeError;
            }
        }
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
