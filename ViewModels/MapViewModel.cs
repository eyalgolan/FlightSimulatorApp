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
    class MapViewModel : INotifyPropertyChanged
    {
        IMapModel model;
        private Location planeLocation = new Location(0,0);
        public MapViewModel(IMapModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
              {
                  NotifyPropertyChanged("VM_" + e.PropertyName);
              };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
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
        public Location VM_Location
        {
            get {
                Console.WriteLine("VM_Latitude is " + VM_Latitude);
                Console.WriteLine("VM_Longitude is " + VM_Longitude);
                planeLocation.Latitude = Convert.ToDouble(VM_Latitude);
                planeLocation.Longitude = Convert.ToDouble(VM_Longitude);
                return planeLocation; }
        }
    }
}
