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
        private double oldx = 0;
        private double oldy = 0;
        private double rudder = 0;
        private double elevator = 0;
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

            if (e.ChangedButton == MouseButton.Left) { fpoint = e.GetPosition(this); }
        }

        private void Knob_MouseUp(object sender, MouseButtonEventArgs e)
        {
            knobPosition.X = 0;
            knobPosition.Y = 0;
            rudder = oldx / 60;
            elevator = -oldy / 60;
            vmGear.moveGear(elevator, rudder);


        }

        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {
           
    


            if (e.LeftButton==MouseButtonState.Pressed)
            {

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
                    vmGear.moveGear(elevator, rudder);


                }
                else
                {

                    Console.WriteLine(rudder);
                    Console.WriteLine(elevator);

                    knobPosition.X = oldx;
                    knobPosition.Y = oldy;
                    rudder = oldx / 59;
                    elevator = -oldy / 59;
                    vmGear.moveGear(elevator, rudder);

                }



            }
            else
            { 

                knobPosition.X = 0;
                knobPosition.Y = 0;
                rudder = oldx / 59;
                elevator = -oldy / 59;
                vmGear.moveGear(elevator, rudder);

            }

        }
        private void Knob_Mouseleave(object sender, MouseEventArgs e)
        {
            knobPosition.X = 0;
            knobPosition.Y = 0;
            rudder = oldx / 60;
            elevator = -oldy / 60;
            vmGear.moveGear(elevator, rudder);

        }
        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            vmGear.airlonchange(e.NewValue);
        }

        private void Slider_ValueChanged_2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            vmGear.thurtelchange(e.NewValue);


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

      
    }

}
