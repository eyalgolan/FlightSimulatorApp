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

        public Location VM_NewPath
        {
            get
            {
                return this.newPath;
            }
            set
            {
                this.newPath = value;
                VM_PlanePath.Add(VM_NewPath);
            }
        }
        public LocationCollection VM_PlanePath
        {
            get
            {
                return this.planePath;
            }
        }
        //Properties
        public String VM_Latitude
        {
            get { return model.Latitude; }
        }
        public String VM_Longitude
        {
            get { return model.Longitude; }
        }
        public String VM_LatitudeError
        {
            get
            {
                return this.model.LatitudeError;
            }
        }
        public String VM_LongitudeError
        {
            get
            {
                return this.model.LongitudeError;
            }
        }
        public String VM_FlightData
        {
            get 
            {
                Console.WriteLine("VM_Latitude is " + VM_Latitude);
                Console.WriteLine("VM_Longitude is " + VM_Longitude);
                VM_NewPath = new Location(Convert.ToDouble(VM_Latitude),Convert.ToDouble(VM_Longitude));
                return model.FlightData; 
            }
        }
    }
}
