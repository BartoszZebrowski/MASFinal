using MASFinal.Backend.Models;
using MASFinal.ViewModels.Common;
using MASFinal.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MASFinal.ViewModels
{
    class VehicleDetailsViewModel : NotifyPropertyChanged
    {
        private IVehicle _groundVehicle;
        public IVehicle GroundVehicle
        {
            get => _groundVehicle;
            set => SetField(ref _groundVehicle, value);
        }
        public ICommand NavigateToRepairDateSelector { get; set; }

        public VehicleDetailsViewModel(IVehicle groundVehicle)
        {
            GroundVehicle = groundVehicle;

            //NavigateToRepairDateSelector = new RelayCommand(
            //    _ => MainWindowViewModel.GetInstance().ChangePage(new RepairDateSelector(GroundVehicle)));

            OnPropertyChanged(nameof(GroundVehicle));
        }
    }
}
