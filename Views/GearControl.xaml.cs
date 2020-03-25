using FlightSimulatorApp.Models;
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
using SimpleTCP;
using System.Net;
using System.Net.Sockets;
using FlightSimulatorApp.ViewModels;
using FlightSimulatorApp.Models;

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for GearControl.xaml
    /// </summary>
    public partial class GearControl : UserControl
    {
        double oldx = 0;
        double oldy = 0;
        double rudder = 0;
        double elevator = 0;
        ITelnetClient TCinstance;
        GearViewModel vmGear;
        public GearControl(ITelnetClient tc)
        {
            InitializeComponent();
            this.TCinstance = tc;
            vmGear = new GearViewModel(new MyGearModel(TCinstance));
            DataContext = vmGear;
        }
       
        
        private void centerKnob_Completed(object sender, EventArgs e) { }
        private Point fpoint = new Point();
        private void Knob_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Console.WriteLine("Knob_MouseDown");
            TcpClient client;
            IPEndPoint ep;
            ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5402);
            client = new TcpClient();
            client.Connect(ep);
            NetworkStream nwStream = client.GetStream();

            if (nwStream.CanWrite)
            {

                byte[] byteToSend = ASCIIEncoding.ASCII.GetBytes("get /position/latitude-deg\n");
                nwStream.Write(byteToSend, 0, byteToSend.Length);
            }
            else
            {
                Console.WriteLine(" You cannot write to this.");
            }
            Console.WriteLine("beforee");

            NetworkStream myNetworkStream = client.GetStream();
            Console.WriteLine("after");

            if (myNetworkStream.CanRead)
            {
                Console.WriteLine("beforee22222");

                byte[] myReadBuffer = new byte[1024];
                StringBuilder myCompleteMessage = new StringBuilder();
                int numberOfBytesRead = 0;
                Console.WriteLine("after222222");

                do
                {
                    Console.WriteLine("44444444");

                    numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);
                                    Console.WriteLine("after33333333333");

                    myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
                }
                while (myNetworkStream.DataAvailable);
                Console.WriteLine("after33333333333");

                // Print out the received message to the console.
                Console.WriteLine("You received the following message : " +
                                             myCompleteMessage);

            }
            else
            {
                Console.WriteLine("Sorry.  You cannot read from this NetworkStream.");

            }
            if (e.ChangedButton == MouseButton.Left) { fpoint = e.GetPosition(this); }
        }

        private void Knob_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Knob_MouseUp");
              knobPosition.X = 0;
             knobPosition.Y = 0;
            rudder = oldx / 60;
            elevator = -oldy / 60;

        }

        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine("aaaaa");
           
    


            if (e.LeftButton==MouseButtonState.Pressed)
            {
                Console.WriteLine("bbbbbbb");

                double x = e.GetPosition(this).X - fpoint.X;
                double y = e.GetPosition(this).Y - fpoint.Y;
               


                if (Math.Sqrt(x*x + y*y)< 120 / 2)
                {
                    knobPosition.X = x;
                    knobPosition.Y = y;
                    oldx = knobPosition.X;
                    oldy = knobPosition.Y;
                    rudder = oldx / 59;
                     elevator = -oldy/59;
                    Models.IGearModel gear;
                    

                }
                else
                {

                    Console.WriteLine(rudder);
                    Console.WriteLine(elevator);

                    knobPosition.X = oldx;
                    knobPosition.Y = oldy;
                    rudder = oldx / 59;
                    elevator = -oldy / 59;
                }

               
                
            }
            else
            { 
                Console.WriteLine("ddddddd");

                knobPosition.X = 0;
                knobPosition.Y = 0;
                rudder = oldx / 59;
                elevator = -oldy / 59;
            }

        }
        private void Knob_Mouseleave(object sender, MouseEventArgs e)
        {
            knobPosition.X = 0;
            knobPosition.Y = 0;
            rudder = oldx / 60;
            elevator = -oldy / 60;

        }
        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Slider_ValueChanged_2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

      
    }

}
