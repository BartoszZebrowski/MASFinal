﻿using MASFinal.Backend.Models;
using MASFinal.ViewModels;
using System;
using System.Collections.Generic;
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

namespace MASFinal.Views
{
    /// <summary>
    /// Interaction logic for VehicleDetails.xaml
    /// </summary>
    public partial class VehicleDetails : Page
    {
        public VehicleDetails(IVehicle groundVehicle)
        {
            DataContext = new VehicleDetailsViewModel(groundVehicle);
            InitializeComponent();
        }
    }
}
