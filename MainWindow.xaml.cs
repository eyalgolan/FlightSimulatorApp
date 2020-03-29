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
using FlightSimulatorApp.Views;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyTelnetClient TCinstance = MyTelnetClient.Instance;
            this.connectionControl.Content = new ConnectionControl(TCinstance);
            this.mapControl.Content = new MapControl(TCinstance);
            this.gearControl.Content = new GearControl(TCinstance);
            this.dashboardControl.Content = new DashboardControl(TCinstance);
        }
    }
}