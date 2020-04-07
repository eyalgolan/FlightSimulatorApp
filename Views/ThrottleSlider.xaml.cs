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
    /// Interaction logic for ThrottleSlider.xaml
    /// </summary>
    public partial class ThrottleSlider : UserControl
    {
        public ThrottleSlider()
        {
            InitializeComponent();
        }

        public double secondslider
        {
            get { return (double)GetValue(secondsliderProperty); }
            set { SetValue(secondsliderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for slidertwo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty secondsliderProperty =
            DependencyProperty.Register("secondslider", typeof(double), typeof(ThrottleSlider));

        private void Slider_ValueChanged_2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            secondslider = e.NewValue;
            // vmGear.thurtelchange(e.NewValue);

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
