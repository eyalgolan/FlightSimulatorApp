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
    /// Interaction logic for AileronSlider.xaml
    /// </summary>
    public partial class AileronSlider : UserControl
    {
        public AileronSlider()
        {
            InitializeComponent();
        }
        public double firstslider
        {
            get { return (double)GetValue(firstsliderProperty); }
            set { SetValue(firstsliderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for sliderone.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty firstsliderProperty =
            DependencyProperty.Register("firstslider", typeof(double), typeof(AileronSlider));

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            firstslider = e.NewValue;
            //  vmGear.airlonchange(e.NewValue);

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
