using System.Windows.Controls;
using FlightSimulatorApp.ViewModels;

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for DashboardControl.xaml
    /// </summary>
    public partial class DashboardControl : UserControl
    {
        private DashboardViewModel vmDashboard;
        public DashboardControl()
        {
            InitializeComponent();
        }
        // Setting the dashboard control view model
        public void SetVM(DashboardViewModel dashboard_VM)
        {
            this.vmDashboard = dashboard_VM;
        }
    }
}
