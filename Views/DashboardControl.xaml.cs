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
        public void setVM(DashboardViewModel dashboard_VM)
        {
            this.vmDashboard = dashboard_VM;
        }
    }
}
