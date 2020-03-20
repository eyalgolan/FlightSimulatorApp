using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulatorApp.Models
{
    interface IMapModel : INotifyPropertyChanged
    {

        //simulator properties
        double latitude { set; get; }
        double longitude { set; get; }
        double angle { set; get; }

        void startReadingFlightData();
        string getFlightData();
    }
}
