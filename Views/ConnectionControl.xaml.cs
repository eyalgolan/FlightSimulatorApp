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
    /// Interaction logic for ConnectionControl.xaml
    /// </summary>
    public partial class ConnectionControl : UserControl
    {
        ConnectionViewModel vmConnect;
        ITelnetClient TCinstance;
        public ConnectionControl(ITelnetClient tc)
        {
            InitializeComponent();
            this.TCinstance = tc;
            vmConnect = new ConnectionViewModel(new MyTelnetClient());
            this.DataContext = this.vmConnect;
        }
        // the connect button
        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            vmConnect.connectToSimulator();
        }
        private void btnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            vmConnect.disconnectSimulator();
        }
    }
}

