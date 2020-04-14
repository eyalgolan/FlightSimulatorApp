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
        string VerticslSpeed { set; get; }
        string GraoundSpeed { set; get; }
        string Heading { set; get; }
        string Aliemeter { set; get; }
        string Pitch { set; get; }
        string Roll { set; get; }
        string ALtitude { set; get; }
        string Airspeed { set; get; }
        string VertivalSpeedColor { set; get; }
        string GroundSpeedColor { set; get; }
        string HeadingColor { set; get; }
        string AlimeterColor { set; get; }
        string PichColor { set; get; }
        string RollColor { set; get; }
        string AltitudeColor { set; get; }
        string AirSpeedColor { set; get; }
    }
}
