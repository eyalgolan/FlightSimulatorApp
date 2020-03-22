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

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for GearControl.xaml
    /// </summary>
    public partial class GearControl : UserControl
    {
        public GearControl()
        {
            InitializeComponent();

        }
        private void centerKnob_Completed(object sender, EventArgs e) { }
        private Point fpoint = new Point();
        private void Knob_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Knob_MouseDown");

            if (e.ChangedButton == MouseButton.Left) { fpoint = e.GetPosition(this); }
        }

        private void Knob_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Knob_MouseUp");
              knobPosition.X = fpoint.X;
             knobPosition.Y = fpoint.Y;
        }

        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.LeftButton==MouseButtonState.Pressed)
            {

                double x = e.GetPosition(this).X - fpoint.X;
                double y = e.GetPosition(this).Y - fpoint.Y;
                if (Math.Sqrt(x*x + y*y)< base.Width / 2)
                {
                    knobPosition.X = x;
                    knobPosition.Y = y;
                }
            }
        }
    }
}
