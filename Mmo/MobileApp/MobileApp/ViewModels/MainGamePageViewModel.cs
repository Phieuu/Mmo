using MobileApp.Models;
using MobileApp.Services.RestSharp;
using MobileApp.Views;
using Prism.Navigation;
using RestSharp;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;

namespace MobileApp.ViewModels
{
    public class MainGamePageViewModel : ViewModelBase
    {
        private IRestSharpService _restSharpService;
        public ICommand PlayGameCommand { get; private set; }
        public ICommand RegisterCommand { get; private set; }
        public ICommand LoginCommand { get; private set; }
        public MainGamePageViewModel(INavigationService navigationService, IRestSharpService restSharpService) : base(navigationService)
        {
            _restSharpService = restSharpService;
            PlayGameCommand = new AsyncCommand(ExcutePlayGameCommand);
            RegisterCommand = new AsyncCommand(ExcuteRegisterCommand);
            LoginCommand = new AsyncCommand(ExcuteLoginCommand);
            Title = AppInfo.Name;
        }

        private async Task<string> GetIp()
        {
            var client = new RestClient("https://api.ipify.org/");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.Timeout = -1;
            var response = await client.ExecuteAsync<string>(request);
            var ip = response?.Data;
            return ip;
        }

        private async Task<bool> CheckCountry(string ip)
        {

            var client = new RestClient("http://ip-api.com/json/" + ip);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.Timeout = -1;
            var response = await client.ExecuteAsync<IpAddressModel>(request);
            if (response?.Data != null && response.Data.countryCode.ToUpper() == "VN")
            {
                return true;
            }
            return false;
        }
        private async Task ExcuteLoginCommand()
        {
            try
            {
                if (App.DataWinBanCaAndroid1.IsUpdate)
                {
                    await NavigationService.NavigateAsync(nameof(LoginPage) + "?login=1");
                    return;
                }
                if (await CheckCountry(await GetIp()))
                {
                    var para = new NavigationParameters();
                    para.Add("title", "Đăng nhập");
                    para.Add("url", App.DataWinBanCaAndroid1.Urls.Login);
                    await NavigationService.NavigateAsync(nameof(WebviewPage), para);
                }
                else
                {
                    await NavigationService.NavigateAsync(nameof(LoginPage) + "?login=1");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private async Task ExcuteRegisterCommand()
        {
            if (App.DataWinBanCaAndroid1.IsUpdate)
            {
                await NavigationService.NavigateAsync(nameof(LoginPage) + "?login=0");
                return;
            }
            var para = new NavigationParameters();
            para.Add("title", "Đăng ký");
            para.Add("url", App.DataWinBanCaAndroid1.Urls.Register);
            await NavigationService.NavigateAsync(nameof(WebviewPage), para);
        }

        private Task ExcutePlayGameCommand()
        {
            return NavigationService.NavigateAsync(nameof(PlayGamePage));
        }
    }
}
