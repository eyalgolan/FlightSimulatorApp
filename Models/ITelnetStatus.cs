using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulatorApp.Models
{
    interface ITelnetStatus : INotifyPropertyChanged
    {
        String IsConnected { set; get; }
        String ConnectionColor { set; get; }
    }
}
