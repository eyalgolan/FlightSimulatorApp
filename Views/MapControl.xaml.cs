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
        private MapViewModel vmMap;
        public MapControl()
        {
            InitializeComponent();
        }

        public void setVM(MapViewModel map_VM)
        {
            this.vmMap = map_VM;
        }
    }
}
