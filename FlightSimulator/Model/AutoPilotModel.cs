using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FlightSimulator.Model
{
    class AutoPilotModel : BaseNotify
    {

        private String autoPilotStr;
        // property for the string in auto pilot textbox
        public String AutoPilotStr
        {
            get
            {
                return this.autoPilotStr;
            }
            set
            {
                this.autoPilotStr = value;
                if (value.CompareTo("") != 0)
                    Back = Brushes.LightPink;
                NotifyPropertyChanged(AutoPilotStr);
            }
        }

        private Brush _b;
        public Brush Back
        {
            get { return _b; }
            set { _b = value; NotifyPropertyChanged("Back"); }
        }

    }
}
