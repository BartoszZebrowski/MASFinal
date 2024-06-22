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
    public class CreateRepairDetailsViewModel : NotifyPropertyChanged
    {

        public GroundVehicle GroundVehicle { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Mechanic? Mechanic { get; set; }


        private string _descritpion;
        public string Descritpion 
        { 
            get => _descritpion;
            set => SetField(ref _descritpion, value);
        }
        
        private decimal _price;
        public decimal Price 
        { 
            get => _price; 
            set => SetField(ref _price, value); 
        }

        public ICommand SaveRepairCommand { get; set; }
        public ICommand NavigateToMechanicSelector { get; set; }

        public CreateRepairDetailsViewModel(GroundVehicle groundVehicle, DateTime dateFrom, DateTime dateTo)
        {
            GroundVehicle = groundVehicle;
            DateFrom = dateFrom;
            DateTo = dateTo;

            NavigateToMechanicSelector = new RelayCommand(
                _ => new MechanicSelectorWindow(this).ShowDialog());

            SaveRepairCommand = new RelayCommand(
                _ => SaveRepair());

        }

        private void SaveRepair()
        {
            Repair.CreateRepair(Mechanic, GroundVehicle, DateFrom, DateTo, Price, Descritpion);

            new SchedulRepository().AddRepair(GroundVehicle);
            MainWindowViewModel.GetInstance().ChangePage(new VehiclesList());
        }
    }
}
