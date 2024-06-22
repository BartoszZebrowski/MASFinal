using MASFinal.ViewModels;
using System.Windows.Controls;

namespace MASFinal.Views
{
    /// <summary>
    /// Interaction logic for VehiclesList.xaml
    /// </summary>
    public partial class VehiclesList : Page
    {
        public VehiclesList()
        {
            var vehicleListViewModel = new VehicleListViewModel();
            DataContext = vehicleListViewModel;
            vehicleListViewModel.LoadVehicles.Execute(null);

            InitializeComponent();

            //Program.PresentExtension();
        }
    }
}
