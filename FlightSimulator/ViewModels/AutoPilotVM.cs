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
    
    /// <summary>
    /// VM for auto pilot
    /// </summary>
    class AutoPilotVM
    {

        public AutoPilotModel autoPilotModel { get; set; }

        public AutoPilotVM()
        {
            // init color is white
            autoPilotModel = new AutoPilotModel();
            autoPilotModel.Back = Brushes.White;
            //Back = Brushes.White;
        }
        // added str since last OK click
        private String addedStr;
        // prev str to find the added
        private String prevStr = "";

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
            new Thread(() =>
            {
                autoPilotModel.Back = Brushes.White;
                addedStr = removePrefix(autoPilotModel.AutoPilotStr, prevStr);
                IEnumerable<string> commands = addedStr.Split('\n').Select(command => command.Trim())
                    .Where(command => command.Count() > 0);
                
                foreach (var command in commands)
                {
                    CommandClient.Instance.Send(command);
                    Thread.Sleep(2000);
                   
                }
                addedStr = "";
                
                prevStr = autoPilotModel.AutoPilotStr;
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
            autoPilotModel.AutoPilotStr = "";
            this.prevStr = "";
            
        }


    }
}
