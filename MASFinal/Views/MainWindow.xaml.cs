using MASFinal.ViewModels;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        public MainWindow()
        {
            var mainWindowViewModel = MainWindowViewModel.GetInstance();
            mainWindowViewModel.PageChanged += OnPageChanged;

            InitializeComponent();

            DataContext = mainWindowViewModel;
            mainWindowViewModel.ChangePage(new VehiclesList());


        }

        private void OnPageChanged(Page page)
        {
            _mainFrame.Navigate(page);

        }
    }
}