using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulatorApp.Models
{
    //Telnet interface
    public interface ITelnetClient : INotifyPropertyChanged
    {
        //communication commands
        void Connect(string ip, string port);
        void Write(string command);
        string Read(); // blocking call
        void Disconnect();

        //connection propertirs
        String IsConnected { get; set; }
        String ConnectionColor { get; set; }
    }
}
