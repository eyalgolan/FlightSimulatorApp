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

        }

        // Setting the control board view model
        public void SetVM(ConnectionViewModel connectVm)
        {
            this.vmConnect = connectVm;
        }
        // the connect button
        private void BtnConnectClick(object sender, RoutedEventArgs e)
        {
            vmConnect.ConnectToSimulator(); //starting the connection process
            if (String.Equals(vmConnect.VmIsConnected, "Connected"))
            {
                btnConnect.IsEnabled = false;
                btnDisconnect.IsEnabled = true;
            }
        }
        // the disconnect button
        private void BtnDisconnectClick(object sender, RoutedEventArgs e)
        {
            vmConnect.DisconnectSimulator(); //starting the disconnection process
            if (String.Equals(vmConnect.VmIsConnected, "Disconnected"))
            {
                btnConnect.IsEnabled = true;
                btnDisconnect.IsEnabled = false;
            }
        }
    }
}

