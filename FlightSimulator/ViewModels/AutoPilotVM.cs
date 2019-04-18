using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class AutoPilotVM
    {
        private String autoPilotStr;
        public String AutoPilotStr
        {
            get
            {
                return this.autoPilotStr;
            }
            set
            {
                Console.WriteLine(value);
                this.autoPilotStr = value;
            }
        }
        

        private ICommand _okCommand;
        public ICommand OKCommand
        {
            get
            {
                return _okCommand ?? (_okCommand =
                new CommandHandler(() => OnOKClick()));
            }
        }
        private void OnOKClick()
        {
            Console.WriteLine("clicked on ok");
            
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand =
                new CommandHandler(() => OnClearClick()));
            }
        }
        private void OnClearClick()
        {
            Console.WriteLine("clicked on clear");

        }


    }
}
