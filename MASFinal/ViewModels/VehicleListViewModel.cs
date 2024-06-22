using MASFinal.Backend.Context;
using MASFinal.Backend.Models;
using MASFinal.Backend.Services;
using MASFinal.ViewModels.Common;
using MASFinal.Views;
using Microsoft.EntityFrameworkCore;
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
            Vehicles = new VehicleRepository().GetAllVehicles();
            OnPropertyChanged();
        }

    }
}
