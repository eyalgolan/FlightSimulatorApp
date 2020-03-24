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
using FlightSimulatorApp.Models;
using FlightSimulatorApp.ViewModels;

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for DashboardControl.xaml
    /// </summary>
    public partial class DashboardControl : UserControl
    {
        DashboardViewModel vmDashboard;
        ITelnetClient TCinstance;
        public DashboardControl(ITelnetClient tc)
        {
            InitializeComponent();
            this.TCinstance = tc;
            vmDashboard = new DashboardViewModel(new MyDashboardModel(TCinstance));
            DataContext = vmDashboard;
        }
    }
}
