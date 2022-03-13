using MobileApp.Views;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace MobileApp.ViewModels
{
    public class HomeGamePageViewModel : ViewModelBase
    {
        public ICommand NavigationCommand { get; private set; }
        public HomeGamePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigationCommand = new AsyncCommand(ExcuteNavigationCommand);
        }

        private Task ExcuteNavigationCommand()
        {
            return NavigationService.NavigateAsync(nameof(MainGamePage));
        }
    }
}
