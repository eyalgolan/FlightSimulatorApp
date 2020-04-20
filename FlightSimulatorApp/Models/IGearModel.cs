using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulatorApp.Models
{
    //Gear interface
    public interface IGearModel
    {
        //commands
        void SetThrottle(double value);
        void SetRudder(double value);
        void SetElevator(double value);
        void SetAileron(double value);
    }
}
