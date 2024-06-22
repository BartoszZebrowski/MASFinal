using MASFinal.Backend.Models;
using MASFinal.Backend.Services;
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
        private Mechanic _selectedMechanic;
        public Mechanic SelectedMechanic 
        { 
            get => _selectedMechanic; 
            set => SetField(ref _selectedMechanic, value); 
        }
        public List<Mechanic> Mechanics { get; set; } = new();
        public ICommand SelectMechanic { get; set; }


        private CreateRepairDetailsViewModel _createRepairDetailsViewModel;

        public MechanicSelectorViewModel(CreateRepairDetailsViewModel createRepairDetailsViewModel)
        {
            _createRepairDetailsViewModel = createRepairDetailsViewModel;

            SelectMechanic = new RelayCommand(
                _ => _createRepairDetailsViewModel.Mechanic = SelectedMechanic,
                _ => SelectedMechanic is not null);

            GetMechanics();
        }

        private void GetMechanics()
        {
            Mechanics = new PersonRepository().GetAllMechanics().ToList();
            OnPropertyChanged();
        }
    }
}
