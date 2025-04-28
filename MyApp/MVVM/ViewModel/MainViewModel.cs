using MyApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ViewTwoCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }

        public ViewTwoModel TwoVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value;
                OnPropertyChanged();
            }

        }

        public MainViewModel() 
        { 
            HomeVM = new HomeViewModel();
            TwoVM = new ViewTwoModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o => 
            { 
                CurrentView = HomeVM;
            });
            ViewTwoCommand = new RelayCommand(o => 
            { 
                CurrentView = TwoVM;
            });
        }
    }
    
}
