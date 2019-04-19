using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

using System.Windows.Media;


namespace FlightSimulator.ViewModels
{
    class AutoPilotVM : BaseNotify
    {
        public AutoPilotVM()
        {
            Back = Brushes.White;
        }
        private String addedStr;
        private String prevStr = "";

        private String autoPilotStr;
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
            new Thread(() =>
            {
                addedStr = removePrefix(AutoPilotStr, prevStr);
                //Console.WriteLine();
                IEnumerable<string> commands = addedStr.Split('\n').Select(command => command.Trim())
                    .Where(command => command.Count() > 0);
                
                foreach (var command in commands)
                {
                    CommandClient.Instance.Send(command);
                    Console.WriteLine("message: " + command);
                }
                addedStr = "";
                Back = Brushes.White;
                prevStr = AutoPilotStr;
            }).Start();
        }
        private String removePrefix(String str, String prefix)
        {
            String final = "";
            if (str != null && str.StartsWith(prefix))
            {
                final = str.Substring(prefix.Length);
            }
            return final;
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
            this.AutoPilotStr = "";
            this.prevStr = "";
            
        }


    }
}
