using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulatorApp.Models
{
    public interface ITelnetClient : INotifyPropertyChanged
    {
        void connect(string ip, int port);
        void write(string command);
        string read(); // blocking call
        void disconnect();

        bool getConnectionStatus();
        String IsConnected { get; set; }
        String ConnectionColor { get; set; }
    }
}
