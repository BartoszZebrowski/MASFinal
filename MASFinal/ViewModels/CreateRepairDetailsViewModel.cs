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
    class CreateRepairDetailsViewModel : NotifyPropertyChanged
    {
        public GroundVehicle GroundVehicle { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Mechanic Mechanic { get; set; }
        public string Descritpion { get; set; }
        public decimal Price { get; set; }


        public ICommand SaveRepairCommand { get; set; }
        public ICommand NavigateToSelectMechanic { get; set; }

        public CreateRepairDetailsViewModel(GroundVehicle groundVehicle, DateTime dateFrom, DateTime dateTo)
        {
            GroundVehicle = groundVehicle;
            DateFrom = dateFrom;
            DateTo = dateTo;

            NavigateToSelectMechanic = new RelayCommand(
                _ => MainWindowViewModel.GetInstance().ChangePage(new MechanicSelector()));

            SaveRepairCommand = new RelayCommand(
                _ => SaveRepair());

        }

        private void SaveRepair()
        {
            Repair.CreateRepair(Mechanic, GroundVehicle, DateFrom, DateTo, Price, Descritpion);




            // uzyc serwisu do zapisywania samochodu 
        }
    }
}
