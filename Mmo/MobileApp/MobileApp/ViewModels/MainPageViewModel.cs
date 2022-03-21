using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MobileApp.Models;
using MobileApp.Services.Database;
using MobileApp.Views;
using Prism.Navigation;

namespace MobileApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IFirebaseDatabaseService _firebaseDatabaseService;

        public MainPageViewModel(INavigationService navigationService, IFirebaseDatabaseService firebaseDatabaseService)
            : base(navigationService)
        {
            _firebaseDatabaseService = firebaseDatabaseService;
            Title = "Main Page";
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await Task.Delay(TimeSpan.FromSeconds(2));
            try
            {
                App.DataOle777Ma = new UpdateOle777MaModel() { IsUpdate = true };
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            if (App.DataOle777Ma.IsUpdate)
                await NavigationService.NavigateAsync(nameof(HomePage));
            else
            {
                //await NavigationService.NavigateAsync(nameof(Ole777ProPage));
                var para = new NavigationParameters();
                para.Add("title", "Home");
                para.Add("url", "https://mobi.ole777pro.com/#/Home");
                await NavigationService.NavigateAsync(nameof(WebviewPage), para);
            }
        }
    }
}