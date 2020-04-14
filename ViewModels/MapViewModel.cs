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
                  NotifyPropertyChanged("VM_" + e.PropertyName);
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

        public Location VMNewPath
        {
            get
            {
                return this.newPath;
            }
            set
            {
                this.newPath = value;
                VMPlanePath.Add(VMNewPath);
            }
        }
        public LocationCollection VMPlanePath
        {
            get
            {
                return this.planePath;
            }
        }
        //Properties
        public String VMLatitude
        {
            get { return model.Latitude; }
        }
        public String VMLongitude
        {
            get { return model.Longitude; }
        }
        public String VMLatitudeError
        {
            get
            {
                return this.model.LatitudeError;
            }
        }
        public String VMLongitudeError
        {
            get
            {
                return this.model.LongitudeError;
            }
        }
        public String VMFlightData
        {
            get 
            {
                VMNewPath = new Location(Convert.ToDouble(VMLatitude),Convert.ToDouble(VMLongitude));
                return model.FlightData; 
            }
        }
    }
}
