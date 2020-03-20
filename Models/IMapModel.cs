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

        //commands
        void setAlieron(double val);
        void setElevator(double val);
        void setRudder(double val);
        void setThrottle(double val);
        void startReadingFlightData();
        string getFlightData();
    }
}
