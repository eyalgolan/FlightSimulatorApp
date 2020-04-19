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
        void setThrottle(double value);
        void setRudder(double value);
        void setElevator(double value);
        void setAileron(double value);
    }
}
