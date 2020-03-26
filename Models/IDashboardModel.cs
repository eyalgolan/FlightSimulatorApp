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
        string AIR_SPEED();
        string ALTITUDE();
        string ROLL();
        string PITCH();
        string HEADING();
        string GROUND_SPEED();
        string VERTICAL_SPEED();

    }
}
