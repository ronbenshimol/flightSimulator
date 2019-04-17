using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class InfoServer :BaseNotify, IDisposable
    {
        
        private TcpClient client;
        TcpListener listener;
        object _syncLock = new object();

        private float lat;
        public float Lat { get { return lat; } set { lat = value; NotifyPropertyChanged("Lat"); } }

        private float lon;
        public float Lon { get { return lon; } set { lon = value; NotifyPropertyChanged("Lon"); } }


        private InfoServer()
        {

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


        public void start()
        {
            int listenPort = ApplicationSettingsModel.Instance.FlightInfoPort;
            string serverIp = ApplicationSettingsModel.Instance.FlightServerIP;
            IPAddress localAdd = IPAddress.Parse(serverIp);

            listener = new TcpListener(localAdd, listenPort);
            Console.WriteLine("Listening...");
            listener.Start();

            client = listener.AcceptTcpClient();

            Console.WriteLine("client connected!");
            
            Thread serverLitenerThread = new Thread(() =>
            {

                using (StreamReader reader = new StreamReader(client.GetStream(), Encoding.UTF8))
                {
                    lock(_syncLock)
                    {
                        
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine("server: " + line);
                        }
                    }
                }


            });

            serverLitenerThread.Start();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
