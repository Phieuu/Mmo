using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MobileApp.Models;
using MobileApp.Services.Database;
using MobileApp.Views;
using Prism.Navigation;
using Xamarin.Essentials;

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
                //var insert = await _firebaseDatabaseService.AddItemAsync(new UpdateNew88iOsModel()
                //{
                //    IsUpdate = true,
                //    AppName = AppInfo.PackageName,
                //    Urls = new AppUrlModel()
                //    {
                //        Afiliate = "http://111win456.com/",
                //        Login = "http://111win456.com/",
                //        Promotion = "http://111win456.com/",
                //        Register = "http://111win456.com/",
                //        Support = "http://111win456.com/"
                //    }
                //});
                var data = await _firebaseDatabaseService.GetItemAsync<UpdateNew88iOsModel>();
                if (data != null)
                    App.DataNew88IOs = data;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            await NavigationService.NavigateAsync(nameof(HomeGamePage));
        }
    }
}