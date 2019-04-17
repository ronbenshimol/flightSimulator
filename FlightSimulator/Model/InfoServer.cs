using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class InfoServer :BaseNotify, IDisposable
    {
        private int listenPort = 5400;
        private const string serverIp = "127.0.0.1";
        private TcpClient client;
        TcpListener listener;

        private float lat;
        public float Lat { get { return lat; } set { lat = value; NotifyPropertyChanged("Lat"); } }

        private float lon;
        public float Lon { get { return lon; } set { lon = value; NotifyPropertyChanged("Lon"); } }


        private InfoServer()
        {
            startListen();
        }
        private static InfoServer instance = null;
        public static InfoServer Instence
        {
            get
            {
                if (instance == null)
                    instance = new InfoServer();
                return instance;
            }
        }


        private void startListen()
        {
            IPAddress localAdd = IPAddress.Parse(serverIp);
            listener = new TcpListener(localAdd, listenPort);
            Console.WriteLine("Listening...");
            listener.Start();

            client = listener.AcceptTcpClient();

            Console.WriteLine("client connected!");


        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
