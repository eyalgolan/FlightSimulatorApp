using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Maps.MapControl.WPF;

namespace FlightSimulatorApp.Models
{
    public interface IMapModel : INotifyPropertyChanged
    {
        //simulator properties
        String FlightData { set; get; }
        String Latitude { set; get; }
        String Longitude { set; get; }
        String LatitudeError { set; get; }
        String LongitudeError { set; get; }
        void startReadingFlightData();
    }
}
