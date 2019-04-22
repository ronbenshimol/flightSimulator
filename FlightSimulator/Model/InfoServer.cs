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
    public class InfoServer : BaseNotify, IDisposable
    {
        
        TcpClient client;
        TcpListener listener;
        object _syncLock = new object();
        object _syncLock2 = new object();
        bool isAlive;
        Thread serverLitenerThread;

        private float lat;
        public float Lat { get { return lat; } set { lat = value; NotifyPropertyChanged("Lat"); } }

        private float lon;
        public float Lon { get { return lon; } set { lon = value; NotifyPropertyChanged("Lon"); } }

        public Action<float,float> lonLatChanged;

        private InfoServer()
        {
        }

        private static InfoServer instance = null;
        /// <summary>
        /// singleton class
        /// </summary>
        public static InfoServer Instance
        {
            get
            {
                if (instance == null)
                    instance = new InfoServer();
                return instance;
            }
        }


        public void Start()
        {

            int listenPort = ApplicationSettingsModel.Instance.FlightInfoPort;
            string serverIp = "0.0.0.0";
            IPAddress localAdd = IPAddress.Parse(serverIp);

            //start listener
            listener = new TcpListener(localAdd, listenPort);
            listener.Start();

            Console.WriteLine("listening...");

            //listen to connection
            client = listener.AcceptTcpClient();
            isAlive = true;

            Console.WriteLine("flightgear connected.");

            //start thread of server
            serverLitenerThread = new Thread(() =>
            {
                try
                {
                    //getting socket stream and read lines
                    using (StreamReader reader = new StreamReader(client.GetStream(), Encoding.UTF8))
                    {
                        lock (_syncLock)
                        {

                            string line;
                            while (isAlive && (line = reader.ReadLine()) != null)
                            {

                                string[] valuesStr = line.Split(',');
                                
                                Lon = float.Parse(valuesStr[0]);
                                Lat = float.Parse(valuesStr[1]);

                                Console.WriteLine("lon:" + Lon +" ,lat:" + Lat);

                                lonLatChanged?.Invoke(Lon, Lat);

                                reader.DiscardBufferedData();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }

            });

            //start the thread of the server
            serverLitenerThread.Start();

        }

        public void Close()
        {
            //close sourcess
            lock (_syncLock2)
            {
                client?.Close();
                isAlive = false;
            }
        }

        public void Dispose()
        {
            Close();
        }
    }
}
