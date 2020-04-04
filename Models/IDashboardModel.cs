using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulatorApp.Models
{
    public interface IDashboardModel : INotifyPropertyChanged
    {
        string VERTICAL_SPEED { set; get; }
        string GROUND_SPEED { set; get; }
        string HEADING { set; get; }
        string ALTIMETER { set; get; }
        string PITCH { set; get; }
        string ROLL { set; get; }
        string ALTITUDE { set; get; }
        string AIR_SPEED { set; get; }
        string VERTICAL_SPEED_COLOR { set; get; }
        string GROUND_SPEED_COLOR { set; get; }
        string HEADING_COLOR { set; get; }
        string ALTIMETER_COLOR { set; get; }
        string PITCH_COLOR { set; get; }
        string ROLL_COLOR { set; get; }
        string ALTITUDE_COLOR { set; get; }
        string AIR_SPEED_COLOR { set; get; }
    }
}
