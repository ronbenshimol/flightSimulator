using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {

        private float lon;

        public float Lon
        {
            get { return lon; }
            set { lon = value; NotifyPropertyChanged("Lon"); }
        }

        private float lat;

        public float Lat
        {
            get { return lat; }
            set { lat = value; NotifyPropertyChanged("Lat"); }
        }



        public FlightBoardViewModel()
        {
            InfoServer.Instance.lonLatChanged += lonLatChangedHandler;
        }

        private void lonLatChangedHandler(float newLon, float newLat)
        {
            Lon = newLon; Lat = newLat;
        }
        
    }
}
