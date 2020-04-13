using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FlightSimulatorApp.ViewModels;
namespace FlightSimulatorApp.Models
{
    class MyGearModel : IGearModel
    {

        ITelnetClient tc;
        GearViewModel vm;

        private double throttle;
        private double rudder;
        private double elevator;
        private double aileron;

        private string throttleCommand = "set /controls/engines/current-engine/throttle ";
        private string rudderCommand = "set /controls/flight/rudder ";
        private string elevatorCommand = "set /controls/flight/elevator ";
        private string aileronCommand = "set /controls/flight/aileron ";

        Queue<string> writeQueue;

        public double Throttle
        {
            get { return throttle; }
            set
            {
                Console.WriteLine("entered changing throttle, tc.IsConnected is " + tc.IsConnected);
                if (String.Equals(tc.IsConnected, "Connected"))
                {
                    Console.WriteLine("chnaging throttle to " + value);
                    string command = throttleCommand + value + "\n";
                    this.writeQueue.Enqueue(command);
                    this.throttle = value;
                }
            }
        }
        public double Rudder
        {
            get { return rudder; }
            set
            {
                string command = rudderCommand + value + "\n";
                this.writeQueue.Enqueue(command);
                this.rudder = value;
            }
        }
        public double Elevator
        {
            get
            {
                return elevator;
            }
            set
            {
                string command = elevatorCommand + value + "\n";
                this.writeQueue.Enqueue(command);
                this.elevator = value;

            }
        }
        public double Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                string command = aileronCommand + value + "\n";
                this.writeQueue.Enqueue(command);
                this.aileron = value;
            }
        }

        public MyGearModel(ITelnetClient tc, GearViewModel vm)
        {
            this.vm = vm;
            this.tc = tc;
            vm.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged(e.PropertyName);
                Console.WriteLine(e.PropertyName + "changed ##################################");
            };
            this.writeQueue = new Queue<string>();
            startWriting();
        }

        private void startWriting()
        {
            new Thread(delegate ()
            {
                while (true)
                {
                    if (String.Equals(tc.IsConnected, "Connected") && this.writeQueue.Count != 0)
                    {
                        string writeCommand = writeQueue.Peek();
                        writeQueue.Dequeue();

                        tc.write(writeCommand);
                        tc.read();
                    }
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
