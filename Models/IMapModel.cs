﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulatorApp.Models
{
    interface IMapModel : INotifyPropertyChanged
    {

        //simulator properties
        String FlightData { set; get; }

        void startReadingFlightData();
        string getFlightData();
    }
}
