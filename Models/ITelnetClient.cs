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
        Task write(string command);
        Task<string> read(); // blocking call
        void disconnect();
        String IsConnected { get; set; }
        bool areconected();
        String ConnectionColor { get; set; }

    }
}
