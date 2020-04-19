using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulatorApp.Models
{
    //Dashboard interface
    public interface IDashboardModel : INotifyPropertyChanged
    {
        //Dashboard properties
        string VerticalSpeed { set; get; }
        string GroundSpeed { set; get; }
        string Heading { set; get; }
        string Altimeter { set; get; }
        string Pitch { set; get; }
        string Roll { set; get; }
        string Altitude { set; get; }
        string AirSpeed { set; get; }
        string VerticalSpeedColor { set; get; }
        string GroundSpeedColor { set; get; }
        string HeadingColor { set; get; }
        string AltimeterColor { set; get; }
        string PitchColor { set; get; }
        string RollColor { set; get; }
        string AltitudeColor { set; get; }
        string AirSpeedColor { set; get; }
    }
}
