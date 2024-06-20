using MASFinal.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MASFinal.ViewModels
{
    class MainWindowViewModel : NotifyPropertyChanged
    {
        public event Action<Page> PageChanged;

        private Page _mainPage = null;
        public Page MainPage 
        {
            get => _mainPage;
            private set => SetField(ref _mainPage, value); 
        }

        private static MainWindowViewModel _instance;
        private MainWindowViewModel() { }
        public void ChangePage(Page page)
        {
            MainPage = page;
            PageChanged.Invoke(page);
        }

        public static MainWindowViewModel GetInstance()
        {
            if( _instance is null)
            {
                _instance = new MainWindowViewModel();
            }

            return _instance;
        }
    }
}
