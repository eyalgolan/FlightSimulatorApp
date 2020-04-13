﻿using FlightSimulatorApp.Models;
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
        
        private double rudder;
        private double elevator;
        private double throttle;
        private double aileron;
        public double Rudder
        {
            get { return rudder; }
            set { rudder = value; ; vmGear.VM_RUDDER = value; }

        }
        public double Elevator
        {
            get { return elevator; }
            set { elevator = value; ; vmGear.VM_ELEVATOR = value; }

        }
        public double Aileron
        {
            get { return aileron; }
            set { aileron = value; ; vmGear.VM_AILERON = value; }

        }
        public double Throttle
        {
            get { return throttle; }
            set { throttle = value; ; vmGear.VM_THROTTLE = value; }

        }

        GearViewModel vmGear;

        
        public GearControl()
        {
            InitializeComponent();
        }

        public void setVM(GearViewModel gear_VM)
        {
            this.vmGear = gear_VM;

        }
       

        private Point fpoint = new Point();


      

   
        


      
    }

}
