using FlightSimulatorApp.ViewModels;
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
    /// Interaction logic for sliders.xaml
    /// </summary>
    public partial class sliders : UserControl
    {
        GearViewModel vmGear;
        public sliders()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sliderone = e.NewValue;
          //  vmGear.airlonchange(e.NewValue);

        }

        private void Slider_ValueChanged_2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slidertwo = e.NewValue;
            // vmGear.thurtelchange(e.NewValue);

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        public double sliderone
        {
            get { return (double)GetValue(slideroneProperty); }
            set { SetValue(slideroneProperty, value); }
        }

        // Using a DependencyProperty as the backing store for sliderone.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty slideroneProperty =
            DependencyProperty.Register("sliderone", typeof(double), typeof(sliders));


        public double slidertwo
        {
            get { return (double)GetValue(slidertwoProperty); }
            set { SetValue(slidertwoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for slidertwo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty slidertwoProperty =
            DependencyProperty.Register("slidertwo", typeof(double), typeof(sliders));



    }
    

}
