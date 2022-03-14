using System;
using System.Diagnostics;
using MobileApp.Models;
using MobileApp.Views;
using Newtonsoft.Json;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using MobileApp.Services.RestSharp;
using RestSharp;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;

namespace MobileApp.ViewModels
{
    public class MainGamePageViewModel : ViewModelBase
    {
        private IRestSharpService _restSharpService;
        private string _strLogin;
        private string _strHoTro;

        public string StrHoTro
        {
            get => _strHoTro;
            set => SetProperty(ref _strHoTro, value);
        }

        public string StrLogin
        {
            get => _strLogin;
            set => SetProperty(ref _strLogin, value);
        }

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

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (App.DataNew88IOs.IsUpdate)
            {
                StrLogin = "CHÍNH SÁCH BẢO MẬT";
                StrHoTro = "THÔNG TIN ỨNG DỤNG";
            }
            else
            {
                StrLogin = "ĐĂNG NHẬP";
                StrHoTro = "HỖ TRỢ 24/7";
            }
        }

        private async Task ExcuteLoginCommand()
        {
            try
            {
                var para = new NavigationParameters();
                if (App.DataNew88IOs.IsUpdate)
                {
                    para.Add("title", "Đăng nhập");
                    para.Add("url", "https://www.freeprivacypolicy.com/live/284f8581-51f3-4910-80da-93ec2ee3b703");
                    await NavigationService.NavigateAsync(nameof(WebviewPage), para);
                    return;
                }
                if (await CheckCountry(await GetIp()))
                {

                    para.Add("title", "Đăng nhập");
                    para.Add("url", App.DataNew88IOs.Urls.Login);
                    await NavigationService.NavigateAsync(nameof(WebviewPage), para);
                }
                else
                {
                    para.Add("title", "Đăng nhập");
                    para.Add("url", "https://www.freeprivacypolicy.com/live/284f8581-51f3-4910-80da-93ec2ee3b703");
                    await NavigationService.NavigateAsync(nameof(WebviewPage), para);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private async Task ExcuteRegisterCommand()
        {
            if (App.DataNew88IOs.IsUpdate)
            {
                await NavigationService.NavigateAsync(nameof(LoginPage) + "?login=0");
                return;
            }
            var para = new NavigationParameters();
            para.Add("title", "Đăng ký");
            para.Add("url", App.DataNew88IOs.Urls.Register);
            await NavigationService.NavigateAsync(nameof(WebviewPage), para);
        }

        private Task ExcutePlayGameCommand()
        {
            return NavigationService.NavigateAsync(nameof(PlayGamePage));
        }
    }
}
