using System.Threading;
using System.Windows;
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

            // Binding the views to their suitable view model.
            this.connectionControl.DataContext = (Application.Current as App).connectVM;
            this.connectionControl.setVM((Application.Current as App).connectVM);
            this.gearControl.DataContext = (Application.Current as App).gearVM;
            this.gearControl.setVM((Application.Current as App).gearVM);
            this.dashboardControl.DataContext = (Application.Current as App).dashboardVM;
            this.dashboardControl.setVM((Application.Current as App).dashboardVM);
            this.mapControl.DataContext = (Application.Current as App).mapVM;
            this.mapControl.setVM((Application.Current as App).mapVM);
        }
    }
}
