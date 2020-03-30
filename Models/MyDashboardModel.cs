using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;

namespace FlightSimulatorApp.Models
{
    class MyDashboardModel : IDashboardModel
    {
        private string verticalspeed;
        private string GROUND_SPEED;
        private string HEADING;
        private string ALTIMETER;
        private string PITCH;
        private string ROLL;
        private string ALTITUDE;
        private string AIR_SPEED;




        ITelnetClient tc;
        private bool connect;

        string IDashboardModel.verticalspeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IDashboardModel.GROUND_SPEED { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IDashboardModel.HEADING { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IDashboardModel.ALTIMETER { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IDashboardModel.PITCH { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IDashboardModel.ROLL { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IDashboardModel.ALTITUDE { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IDashboardModel.AIR_SPEED { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MyDashboardModel(ITelnetClient tc)
        {
            this.tc = tc;
            this.connect = true;
            startReadingFlightData();
        }
        public void startReadingFlightData()
        {
            new Thread(delegate ()
            {
                while (connect)
                {
                    tc.write("get /instrumentation/gps/indicated-vertical-speed \n");
                    verticalspeed = tc.read();
                    tc.write("get /instrumentation/gps/indicated-ground-speed-kt \n");
                    GROUND_SPEED = tc.read();
                    tc.write("get /instrumentation/heading-indicator/indicated-heading-deg \n");
                    HEADING = tc.read();
                    tc.write("get /instrumentation/altimeter/indicated-altitude-ft \n");
                    ALTIMETER = tc.read();
                    tc.write("get /instrumentation/attitude-indicator/internal-pitch-deg \n");
                    PITCH = tc.read();
                    tc.write("get /instrumentation/attitude-indicator/internal-roll-deg \n");
                    ROLL = tc.read();
                    tc.write("get /instrumentation/gps/indicated-altitude-ft \n");
                    ALTITUDE = tc.read();
                    tc.write("get /instrumentation/airspeed-indicator/indicated-speed-kt \n");
                    AIR_SPEED = tc.read();

                    Thread.Sleep(250);
                }
            }).Start();
        }
        //INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(String propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
