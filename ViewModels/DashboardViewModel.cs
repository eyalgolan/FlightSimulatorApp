﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlightSimulatorApp.Models;

namespace FlightSimulatorApp.ViewModels
{
    class DashboardViewModel : INotifyPropertyChanged
    {
        IDashboardModel model;

        public DashboardViewModel(IDashboardModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public String VM_VERTICAL_SPEED
        {
            get
            {
                return this.model.VERTICAL_SPEED;
            }
        }

        public String VM_GROUND_SPEED
        {
            get
            {
                return this.model.GROUND_SPEED;
            }
        }

        public String VM_HEADING
        {
            get
            {
                return this.model.HEADING;
            }
        }

        public String VM_ALTIMETER
        {
            get
            {
                return this.model.ALTIMETER;
            }
        }

        public String VM_PITCH
        {
            get
            {
                return this.model.PITCH;
            }
        }

        public String VM_ROLL
        {
            get
            {
                return this.model.ROLL;
            }
        }

        public String VM_ALTITUDE
        {
            get
            {
                return this.model.ALTITUDE;
            }
        }

        public String VM_AIR_SPEED
        {
            get
            {
                return this.model.AIR_SPEED;
            }
        }
    }
}
