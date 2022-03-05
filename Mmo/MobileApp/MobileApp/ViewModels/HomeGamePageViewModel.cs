using MobileApp.Views;
using Prism.Navigation;
using System;
using System.Threading.Tasks;

namespace MobileApp.ViewModels
{
    public class HomeGamePageViewModel : ViewModelBase
    {
        public HomeGamePageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await Task.Delay(TimeSpan.FromSeconds(10));
            await NavigationService.NavigateAsync(nameof(MainGamePage));
        }
    }
}
