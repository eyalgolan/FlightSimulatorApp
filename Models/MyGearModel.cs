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

        //The data sending protocol
        private string throttleCommand = "set /controls/engines/current-engine/throttle ";
        private string rudderCommand = "set /controls/flight/rudder ";
        private string elevatorCommand = "set /controls/flight/elevator ";
        private string aileronCommand = "set /controls/flight/aileron ";

        Queue<string> writeQueue; //Queue responsible for holding the set commands in the proper order


        public MyGearModel(ITelnetClient tc)
        {
            this.tc = tc;
            this.writeQueue = new Queue<string>();
            startWriting();
        }

        // functions responsible for creating the appropriate set commands and adding them to the command queue, based on the changes the user does in the Gear
        public void setThrottle(double value)
        {
            string command = throttleCommand + value + "\n";
            this.writeQueue.Enqueue(command);
        }

        public void setRudder(double value)
        {
            string command = rudderCommand + value + "\n";
            this.writeQueue.Enqueue(command);
        }
        public void setElevator(double value)
        {
            string command = elevatorCommand + value + "\n";
            this.writeQueue.Enqueue(command);
        }
        public void setAileron(double value)
        {
            string command = aileronCommand + value + "\n";
            this.writeQueue.Enqueue(command);
        }

        // We maintain a queue which collects the set commands, and send them to the server in the proper order
        private void startWriting()
        {
            new Thread(delegate ()
            {
                while (true)
                {
                    // sending the data until we disconnected or the queue is empty 
                    if (String.Equals(tc.IsConnected, "Connected") && this.writeQueue.Count != 0)
                    {
                        string writeCommand = writeQueue.Peek();
                        writeQueue.Dequeue();
                        Console.WriteLine(writeCommand);
                        tc.write(writeCommand);
                        tc.read();
                    }
                }
            }).Start();
        }
    }
}
