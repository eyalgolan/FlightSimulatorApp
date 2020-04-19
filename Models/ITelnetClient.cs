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
        void connect(string ip, string port);
        void write(string command);
        string read(); // blocking call
        void disconnect();

        //connection propertirs
        String IsConnected { get; set; }
        String ConnectionColor { get; set; }
    }
}
