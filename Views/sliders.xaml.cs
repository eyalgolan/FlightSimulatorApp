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
