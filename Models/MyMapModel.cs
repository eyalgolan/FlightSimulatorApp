﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Models
{
    class MyMapModel : IMapModel
    {
        public double latitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double longitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double angle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        public string getFlightData()
        {
            throw new NotImplementedException();
        }

        public void startReadingFlightData()
        {
            throw new NotImplementedException();
        }
    }
}
