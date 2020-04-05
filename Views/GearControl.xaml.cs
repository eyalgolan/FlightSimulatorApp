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
        
        private double rudder = 0;
        private double elevator = 0;
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


        public void  movecomand( )
        {
            
           
            vmGear.moveGear(elevator, rudder);
        }

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            vmGear.airlonchange(e.NewValue);
        }

        private void Slider_ValueChanged_2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            vmGear.thurtelchange(e.NewValue);


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

      
    }

}
