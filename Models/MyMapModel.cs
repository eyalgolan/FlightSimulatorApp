using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Models
{
    class MyMapModel : IMapModel
    {
        ITelnetClient tc;
        private String flightData;
        public String FlightData
        {
            set
            {
                flightData = value;
                NotifyPropertyChanged("FlightData");
            }
            get { return flightData; }
        }

        //INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        public string getFlightData()
        {
            return FlightData;
        }

        public void startReadingFlightData()
        {
            new Thread(delegate ()
            {
                while (true)
                {
                    FlightData = tc.read();
                    Thread.Sleep(250);
                }
            }).Start();
        }
    }
}
