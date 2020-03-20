using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Models
{
    class MyGearModel : IGearModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void setAlieron(double val)
        {
            throw new NotImplementedException();
        }

        public void setElevator(double val)
        {
            throw new NotImplementedException();
        }

        public void setRudder(double val)
        {
            throw new NotImplementedException();
        }

        public void setThrottle(double val)
        {
            throw new NotImplementedException();
        }
    }
}
