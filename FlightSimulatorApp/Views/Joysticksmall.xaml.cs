﻿using FlightSimulatorApp.ViewModels;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for Joysticksmall.xaml
    /// </summary>
    public partial class Joysticksmall : UserControl
    {
        public double rudder = 0;
        public double elevator = 0;
        private double oldx = 0;
        private double oldy = 0;
        private Storyboard storyboard;

        public double ypoint
        {
            get { return (double)GetValue(ypointProperty); }
            set { SetValue(ypointProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ypoint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ypointProperty =
            DependencyProperty.Register("ypoint", typeof(double), typeof(Joysticksmall));

        public double xpoint
        {
            get { return (double)GetValue(xpointProperty); }
            set { SetValue(xpointProperty, value); }
        }

        // Using a DependencyProperty as the backing store for xpoint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty xpointProperty =
            DependencyProperty.Register("xpoint", typeof(double), typeof(Joysticksmall));

        public Joysticksmall()
        {
            InitializeComponent();
        }
        private void centerKnob_Completed(object sender, EventArgs e) { }
        private Point fpoint = new Point();
        private void Knob_MouseDown(object sender, MouseButtonEventArgs e)
        {
            storyboard = (Knob.FindResource("CenterKnob") as Storyboard);
            storyboard.Stop();
            Knob.CaptureMouse();
            if (e.ChangedButton == MouseButton.Left) { fpoint = e.GetPosition(this); }
        }
        private void Knob_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // xpoint = 0;
            // ypoint = 0;
            storyboard = (Knob.FindResource("CenterKnob") as Storyboard);
            storyboard.Begin();
            var knobElement = (UIElement)Knob;
            knobElement.ReleaseMouseCapture();
            knobPosition.X = 0;
            knobPosition.Y = 0;
            oldx = 0;
            oldy = 0;
            xpoint = 0;
            ypoint = 0;

        }
        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                double x = e.GetPosition(this).X - fpoint.X;
                double y = e.GetPosition(this).Y - fpoint.Y;

                if (Math.Sqrt(x * x + y * y) < 120 / 2)
                {
                    knobPosition.X = x;
                    knobPosition.Y = y;
                    oldx = knobPosition.X;
                    oldy = knobPosition.Y;
                    rudder = oldx / 60;
                    elevator = -oldy / 60;
                    xpoint = rudder;
                    ypoint = elevator;
                }
                else
                {

                    knobPosition.X = oldx;
                    knobPosition.Y = oldy;
                    rudder = oldx / 60;
                    elevator = -oldy / 60;
                    xpoint = rudder;
                    ypoint = elevator;
                }
            }
            else
            {
                knobPosition.X = 0;
                knobPosition.Y = 0;
                rudder = oldx / 60;
                elevator = -oldy / 60;
                xpoint = rudder;
                ypoint = elevator;
            }
        }
        private void Knob_Mouseleave(object sender, MouseEventArgs e)
        {
            knobPosition.X = 0;
            knobPosition.Y = 0;
            oldx = 0;
            oldy = 0;
            rudder = oldx / 60;
            elevator = -oldy / 60;
            xpoint = rudder;
            ypoint = elevator;
        }
        public Point Getposition()
        {
            return new Point(elevator, rudder);
        }
    }
}