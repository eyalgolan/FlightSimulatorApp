using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FlightSimulatorApp.Views;
using FlightSimulatorApp.Models;
using FlightSimulatorApp.ViewModels;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public ConnectionViewModel connectVM { get; internal set; }
        public DashboardViewModel dashboardVM { get; internal set; }
        public GearViewModel gearVM { get; internal set; }
        public MapViewModel mapVM { get; internal set; }


        // Initializing the simulator models and all of the view models.
        private void Application_Startup(object sender, StartupEventArgs e)
        {

            // Connection part
            MyTelnetClient TCinstance = MyTelnetClient.Instance;
            connectVM = new ConnectionViewModel(TCinstance);

            // Map part
            IMapModel mapModel = new MyMapModel(TCinstance);
            mapVM = new MapViewModel(mapModel);

            // Gear part
            IGearModel gearModel = new MyGearModel(TCinstance);
            gearVM = new GearViewModel(gearModel);

            // Dashboard part
            IDashboardModel dashboardModel = new MyDashboardModel(TCinstance);
            dashboardVM = new DashboardViewModel(dashboardModel);
        }
    }
}