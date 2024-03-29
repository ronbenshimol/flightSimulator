﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlightSimulator.Model;
using FlightSimulator.ViewModels;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    public partial class FlightBoard : UserControl
    {
        //public FlightBoardViewModel FlightBoardVM { get; set; }
        public InfoServer infoServer { get; set; }

        private readonly ObservableDataSource<Point> planeLocations = new ObservableDataSource<Point>();
        public ObservableDataSource<Point> PlaneLocations => planeLocations;

        public FlightBoardViewModel flightBoardViewModel { get; set; }

        //ObservableDataSource<Point> planeLocations = null;
        public FlightBoard()
        {
            InitializeComponent();

            infoServer = InfoServer.Instance;

            flightBoardViewModel = new FlightBoardViewModel();
            flightBoardViewModel.PropertyChanged += Vm_PropertyChanged;
        }
        

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Set identity mapping of point in collection to point on plot
            planeLocations.SetXYMapping(p => p);
            plotter.AddLineGraph(planeLocations, 2, "Route");
        }

        private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("Lat") || e.PropertyName.Equals("Lon"))
            {
                if(infoServer.Lon != 0 && infoServer.Lat != 0) {

                    Console.WriteLine("Lon: " + infoServer.Lon + " ,Lat: " + infoServer.Lat);
                    Point p1 = new Point(infoServer.Lon, infoServer.Lat);            // Fill here!
                    planeLocations.AppendAsync(Application.Current.Dispatcher, p1);
                }

            }
        }

    }

}
