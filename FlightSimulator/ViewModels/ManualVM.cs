using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class ManualVM : BaseNotify
    {

        private double aileron = 0;
        public double Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                aileron = Math.Round(value, 2);
                Console.WriteLine("Aileron = " + Aileron + "   Throttle = " + Throttle + "   Elevator = " + Elevator + "  Rudder = " + Rudder);
                NotifyPropertyChanged("Aileron");
            }
        }

        private double throttle = 0;
        public double Throttle
        {
            get
            {
                return throttle;
            }
            set
            {
                throttle = Math.Round(value, 2);
                Console.WriteLine("Aileron = " + Aileron + "   Throttle = " + Throttle + "   Elevator = " + Elevator + "  Rudder = " + Rudder);
                NotifyPropertyChanged("Throttle");
            }
        }

        private double elevator = 0;
        public double Elevator
        {
            get
            {
                return elevator;
            }
            set
            {
                elevator = Math.Round(value, 2);
                Console.WriteLine("Aileron = " + Aileron + "   Throttle = " + Throttle + "   Elevator = " + Elevator + "  Rudder = " + Rudder);
                NotifyPropertyChanged("Elevator");
            }
        }

        private double rudder = 0;
        public double Rudder
        {
            get
            {
                return rudder;
            }
            set
            {
                rudder = Math.Round(value, 2);
                Console.WriteLine("Aileron = " + Aileron + "   Throttle = " + Throttle + "   Elevator = " + Elevator + "  Rudder = " + Rudder);
                NotifyPropertyChanged("Rudder");
            }
        }


    }
}
