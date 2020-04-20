using FlightSimulatorApp.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FlightSimulatorApp.ViewModels;

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for GearControl.xaml
    /// </summary>
    public partial class GearControl : UserControl
    {
        // all varibel and propetry sets;
        private double rudder;
        private double elevator;
        private double throttle;
        private double aileron;
        public double Rudder
        {
            get { return rudder; }
            set { rudder = value; ; vmGear.VmRudder = value; }
        }
        public double Elevator
        {
            get { return elevator; }
            set { elevator = value; ; vmGear.VmElevator = value; }
        }
        public double Aileron
        {
            get { return aileron; }
            set { aileron = value; ; vmGear.VmAileron = value; }
        }
        public double Throttle
        {
            get { return throttle; }
            set { throttle = value; ; vmGear.VmThrottle = value; }
        }

        GearViewModel vmGear;


        public GearControl()
        {
            InitializeComponent();
        }

        // Setting the gear control view model
        public void SetVM(GearViewModel gearVM)
        {
            this.vmGear = gearVM;
        }
    }
}
