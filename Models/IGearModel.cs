using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulatorApp.Models
{
    public interface IGearModel : INotifyPropertyChanged
    {
        //commands
        double Throttle { set; get; }
        double Rudder { set; get; }
        double Aileron { set; get; }
        double Elevator { set; get; }
        //void startWriting();
    }
}
