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
    class RepairDateSelectorViewModel : NotifyPropertyChanged
    {

        public ICommand NavigateToCreateRepairDetails { get; set; }

        public GroundVehicle GroundVehicle { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }



        public RepairDateSelectorViewModel(GroundVehicle groundVehicle)
        {
            GroundVehicle = groundVehicle;


            NavigateToCreateRepairDetails = new RelayCommand(
                _ => MainWindowViewModel.GetInstance().ChangePage(new CreateRepairDetails(GroundVehicle, DateFrom, DateTo)));
        }
    }
}
