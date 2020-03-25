﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlightSimulatorApp.ViewModels;
using FlightSimulatorApp.Models;

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for MapControl.xaml
    /// </summary>
    public partial class MapControl : UserControl
    {
        MapViewModel vmMap;
        ITelnetClient TCinstance;
        public MapControl(ITelnetClient tc)
        {
            InitializeComponent();
            this.TCinstance = tc;
            vmMap = new MapViewModel(new MyMapModel(TCinstance));
            DataContext = vmMap;
            tc.connect("127.0.0.1", 5402);
            Console.WriteLine("map testtt333333333333");
            Console.WriteLine(vmMap.VM_Latitude);
            Console.WriteLine(vmMap.VM_Longitude);
            Console.WriteLine(vmMap.VM_Location);


        }
    }
}
