using FlightSimulator.Model;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class FlightVM
    {

        private bool isDisconnected = true;
        private ConnectModel connectM = new ConnectModel();

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
            // TODO call to connect in model
            //m_flightManager.Connect();
            //connectM.printConnect();
            isDisconnected = false;

            //init communication
            InfoServer server = InfoServer.Instance;
            server.Start();
            CommandClient commandClient = CommandClient.Instance;
            commandClient.Start();
        }


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
