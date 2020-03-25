using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Maps.MapControl.WPF;

namespace FlightSimulatorApp.Models
{
    interface IMapModel : INotifyPropertyChanged
    {

        //simulator properties
        Location FlightData { set; get; }
        String Latitude { set; get; }
        String Longitude { set; get; }
        void startReadingFlightData();
        string getFlightLongitude();
        string getFlightLatitude();
    }
}
