using FlightSimulator.Model;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels.ButtonsVM
{
    class SettingsButtonVM
    {
        

        private ICommand _settingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                return _settingsCommand ?? (_settingsCommand =
                new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {
            SettingsWindow setWin = new SettingsWindow();
            setWin.Show();

        }
    }
}
