using MASFinal.Backend.Models;
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
    /// Interaction logic for RepairDateSelector.xaml
    /// </summary>
    public partial class RepairDateSelector : Page
    {
        private RepairDateSelectorViewModel _repairDateSelectorViewModel1;

        public RepairDateSelector(GroundVehicle groundVehicle)
        {
            _repairDateSelectorViewModel1 = new RepairDateSelectorViewModel(groundVehicle);
            DataContext = _repairDateSelectorViewModel1;

            _repairDateSelectorViewModel1.PropertyChanged += OnPropertyChange;

            InitializeComponent();
        }

        private void OnPropertyChange(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (_repairDateSelectorViewModel1.IsRented)
                _errorMessage.Visibility = Visibility.Visible;
            else
                _errorMessage.Visibility = Visibility.Hidden;
        }
    }
}
