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
            set { rudder = value; ; vmGear.vm_rudder = value; }

        }
        public double Elevator
        {
            get { return elevator; }
            set { elevator = value; ; vmGear.vm_elevator = value; }

        }
        public double Aileron
        {
            get { return aileron; }
            set { aileron = value; ; vmGear.vm_aileron = value; }

        }
        public double Throttle
        {
            get { return throttle; }
            set { throttle = value; ; vmGear.vm_throttle = value; }

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
