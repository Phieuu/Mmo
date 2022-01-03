using System;
using System.Threading.Tasks;
using Prism.Navigation;

namespace MobileApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await Task.FromResult(TimeSpan.FromSeconds(2));
        }
    }
}