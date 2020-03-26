using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulatorApp.Models
{
    class MyDashboardModel : IDashboardModel
    {
        ITelnetClient tc;
        public MyDashboardModel(ITelnetClient tc)
        {
            this.tc = tc;
        }

        //INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        public string AIR_SPEED()
        {
            throw new NotImplementedException();
        }

        public string ALTITUDE()
        {
            throw new NotImplementedException();
        }

        public string GROUND_SPEED()
        {
            throw new NotImplementedException();
        }

        public string HEADING()
        {
            throw new NotImplementedException();
        }

        public void NotifyPropertyChanged(String propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public string PITCH()
        {
            throw new NotImplementedException();
        }

        public string ROLL()
        {
            throw new NotImplementedException();
        }

        public string VERTICAL_SPEED()
        {
            throw new NotImplementedException();
        }    }
}
