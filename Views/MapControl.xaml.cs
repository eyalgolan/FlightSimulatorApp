using System;
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
using Microsoft.Maps.MapControl.WPF;

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for MapControl.xaml
    /// </summary>
    public partial class MapControl : UserControl
    {
        MapViewModel vmMap;
        ITelnetClient TCinstance;
        double latitude;
        double longitude;
        public MapControl(ITelnetClient tc)
        {
            InitializeComponent();
            this.TCinstance = tc;
            vmMap = new MapViewModel(new MyMapModel(TCinstance));
            DataContext = vmMap;
            MapLayer mapLayer = new MapLayer();
            Image myPushPin = new Image();
            myPushPin.Source = new BitmapImage(new Uri("\\Resources\\plane_icon.png", UriKind.Relative));
            myPushPin.Width = 25;
            myPushPin.Height = 25;
            mapLayer.AddChild(myPushPin, myMap.Center, PositionOrigin.Center);
            myMap.Children.Add(mapLayer);
        }
    }
}
