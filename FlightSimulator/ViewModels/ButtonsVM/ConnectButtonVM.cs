using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels.ButtonsVM
{
    class ConnectButtonVM
    {
        private bool isDisconnected = true;
        private ConnectModel connectM = new ConnectModel();

        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand =
                new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {
            // TODO call to connect in model
            //m_flightManager.Connect();
            connectM.printConnect();
            isDisconnected = false;
        }
    }

}
