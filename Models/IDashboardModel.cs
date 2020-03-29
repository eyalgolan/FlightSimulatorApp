using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulatorApp.Models
{
    interface IDashboardModel : INotifyPropertyChanged
    {
         string verticalspeed { set; get; }
         string GROUND_SPEED { set; get; }
        string HEADING { set; get; }
        string ALTIMETER { set; get; }
        string PITCH { set; get; }
        string ROLL { set; get; }
        string ALTITUDE { set; get; }
        string AIR_SPEED { set; get; }
    }
}
