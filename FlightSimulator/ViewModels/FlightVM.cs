using FlightSimulator.Model;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    /// <summary>
    /// flight view model
    /// </summary>
    class FlightVM
    {
        // connect command
        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand =
                new CommandHandler(() => OnConnectClick()));
            }
        }
        private void OnConnectClick()
        {
            

             new Thread(() =>
            {
                //init communication
                InfoServer server = InfoServer.Instance;
                server.Start();
                CommandClient commandClient = CommandClient.Instance;
                commandClient.Start();

            }).Start();
            
        }

        // settings button
        private ICommand _settingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                return _settingsCommand ?? (_settingsCommand =
                new CommandHandler(() => OnSettingsClick()));
            }
        }
        private void OnSettingsClick()
        {
            SettingsWindow setWin = new SettingsWindow();
            setWin.Show();

        }



    }
}
