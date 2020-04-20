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

            // Binding the views to their suitable view model accurding to the appstartup settings
            this.connectionControl.DataContext = (Application.Current as App).connectVM;
            this.connectionControl.SetVM((Application.Current as App).connectVM);
            this.gearControl.DataContext = (Application.Current as App).gearVM;
            this.gearControl.SetVM((Application.Current as App).gearVM);
            this.gearControl.DataContext = (Application.Current as App).gearVM;
            this.dashboardControl.DataContext = (Application.Current as App).dashboardVM;
            this.dashboardControl.SetVM((Application.Current as App).dashboardVM);
            this.mapControl.DataContext = (Application.Current as App).mapVM;
            this.mapControl.SetVM((Application.Current as App).mapVM);
        }
    }
}
