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
