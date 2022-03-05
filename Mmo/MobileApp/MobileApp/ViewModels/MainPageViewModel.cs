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
                //var insert = await _firebaseDatabaseService.AddItemAsync(new UpdateNew88IOsModel());
                var data = await _firebaseDatabaseService.GetItemAsync<UpdateNew88IOsModel>();
                if (data != null)
                {
                    App.DataNew88IOs = data;
                    if (data.IsUpdate == false)
                    {
                        await NavigationService.NavigateAsync(nameof(HomePage));
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            await NavigationService.NavigateAsync(nameof(HomeGamePage));
        }
    }
}