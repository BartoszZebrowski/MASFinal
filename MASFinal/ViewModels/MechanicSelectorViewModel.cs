using MASFinal.Backend.Models;
using MASFinal.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MASFinal.ViewModels
{
    public class MechanicSelectorViewModel : NotifyPropertyChanged
    {
        public Mechanic SelectedMechanic { get; set; }
        public List<Mechanic> Mechanics { get; set; }
        public ICommand SelectMechanic { get; set; }


        private CreateRepairDetailsViewModel _createRepairDetailsViewModel;

        public MechanicSelectorViewModel(CreateRepairDetailsViewModel createRepairDetailsViewModel)
        {
            _createRepairDetailsViewModel = createRepairDetailsViewModel;

            SelectMechanic = new RelayCommand(_ => _createRepairDetailsViewModel.Mechanic = SelectedMechanic);

            GetMechanics();
        }

        private void GetMechanics()
        {
            // pobieranie mechanikow
        }
    }
}
