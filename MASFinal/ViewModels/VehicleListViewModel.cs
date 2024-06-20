using MASFinal.Backend.Context;
using MASFinal.Backend.Models;
using MASFinal.ViewModels.Common;
using MASFinal.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MASFinal.ViewModels
{
    class VehicleListViewModel : NotifyPropertyChanged
    {
        public List<IVehicle> Vehicles { get; set; }
        public IVehicle SelectedVehicle { get; set; }
        public ICommand LoadVehicles { get; private set; }
        public ICommand NavigateToVehicleDetails { get; private set; }



        public VehicleListViewModel()
        {
            LoadVehicles = new RelayCommand(async (_) => await GetVehicles());

            NavigateToVehicleDetails = new RelayCommand(
                (_) => MainWindowViewModel.GetInstance().ChangePage(new VehicleDetails(SelectedVehicle)),
                (_) => SelectedVehicle is not null);

        }

        private async Task GetVehicles()
        {
            var groundVehicles = await DatabaseContext.GetInstance().GroundVehicles
                .Include(gv => gv.Bus)
                .Include(gv => gv.Camper)
                .ToListAsync();

            var amphibians = await DatabaseContext.GetInstance().Amphibians
                .ToListAsync();

            var boats = await DatabaseContext.GetInstance().Boats
                .ToListAsync();

            List<IVehicle> vehicles = new List<IVehicle>();

            vehicles.AddRange(groundVehicles);
            vehicles.AddRange(amphibians);
            vehicles.AddRange(boats);

            Vehicles = vehicles;


            OnPropertyChanged();
            //GroundVehicle vehicle = new GroundVehicle(
            //    "Saab",           // brand
            //    "93",            // model
            //    150.50m,            // dailyRentalPrice
            //    5,                  // numberOfSeats
            //    new DateTime(2018, 5, 15),  // productionDate
            //    180,                // power
            //    50000,              // mileage
            //    DrivingLicencType.B,       // category
            //    4,                  // numberOfWheels
            //    18                  // rimSize
            //);
            //DriveType.CreateElectricDrive(vehicle, 20, 30);
            //Camper.CreateCamper(vehicle, "dasdasd", true);

            //Vehicles.Add(vehicle);


            //await DatabaseContext.GetInstance().GroundVehicles.AddAsync(vehicle);
            //await DatabaseContext.GetInstance().SaveChangesAsync();
        }

    }
}
