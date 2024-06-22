using MASFinal.Backend.Models;
using MASFinal.Backend.Services;
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
    class RepairDateSelectorViewModel : NotifyPropertyChanged
    {
        public GroundVehicle GroundVehicle { get; set; }

        public ICommand NavigateToCreateRepairDetails { get; set; }

        private bool _isRented = true;
        public bool IsRented
        {
            get => _isRented;
            set => SetField(ref _isRented, value);
        }

        private DateTime? _dateFrom;
        public DateTime? DateFrom
        {
            get => _dateFrom;
            set => SetField(ref _dateFrom, value);
        }

        private DateTime? _dateTo;
        public DateTime? DateTo
        {
            get => _dateTo;
            set => SetField(ref _dateTo, value);
        }

        public RepairDateSelectorViewModel(GroundVehicle groundVehicle)
        {
            GroundVehicle = groundVehicle;

            NavigateToCreateRepairDetails = new RelayCommand(
                _ => SelectDateRepair(),
                _ => !IsRented && DateFrom != null && DateTo != null);

            PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            IsRented = GroundVehicle.Rents.Any(rent => rent.RentalDate <= DateFrom && rent.ReturnDate >= DateTo);
        }

        private void SelectDateRepair()
        {
            MainWindowViewModel.GetInstance().ChangePage(new CreateRepairDetails(GroundVehicle, (DateTime)DateFrom, (DateTime)DateTo));
        }
    }
}
