using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulatorApp.Models
{
    interface IGearModel : INotifyPropertyChanged
    {
        //commands
        void setAileron(double val);
        void setElevator(double val);
        void setRudder(double val);
        void setThrottle(double val);
    }
}
