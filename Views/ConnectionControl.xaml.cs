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
        private ConnectionViewModel vmConnect;
        public ConnectionControl()
        {
            InitializeComponent();
            //vmConnect = new ConnectionViewModel(this.TCinstance);
            //this.DataContext = this.vmConnect;
        }

        // Setting the control board view model.
        public void setVM(ConnectionViewModel connect_VM)
        {
            this.vmConnect = connect_VM;
        }
        // the connect button
        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            vmConnect.connectToSimulator();
            if(String.Equals(vmConnect.VM_IsConnected, "Connected"))
            {
                btnConnect.IsEnabled = false;
                btnDisconnect.IsEnabled = true;
            }
        }
        private void btnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            vmConnect.disconnectSimulator();
            if (String.Equals(vmConnect.VM_IsConnected, "Disconnected"))
            {
                btnConnect.IsEnabled = true;
                btnDisconnect.IsEnabled = false;
            }
        }
    }
}

