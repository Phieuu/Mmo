using MobileApp.FakeModules.Views.AboutUs;
using MobileApp.FakeModules.Views.MyBooking;
using MobileApp.FakeModules.Views.Notification;
using MobileApp.Views;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private int _language = Xamarin.Essentials.Preferences.Get(nameof(Language), 1);
        private IPageDialogService _pageDialogService;

        public int Language
        {
            get => _language;
            set
            {
                if (SetProperty(ref _language, value))
                {
                    Preferences.Set(nameof(Language), value);
                }
            }
        }

        public ICommand SelectLanguageCommand { get; private set; }
        public ICommand OpenMenuCommand { get; set; }

        public HomePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            OpenMenuCommand = new Command<string>(OpenMenuCommandExcute);
            SelectLanguageCommand = new AsyncCommand<string>(SelectLanguageCommandExcute);
        }

        private Task SelectLanguageCommandExcute(string arg)
        {
            switch (arg)
            {
                case "0":
                    Language = 0;

                    break;

                case "1":
                    Language = 1;

                    break;

                case "2":
                    Language = 2;

                    break;

                case "3":
                    Language = 3;

                    break;

                case "4":
                    Language = 4;

                    break;

                default:
                    Language = 0;
                    break;
            }

            return Task.FromResult(0);
        }

        private void OpenMenuCommandExcute(string key)
        {
            try
            {
                if (App.DataWinBanCaAndroid1.IsUpdate)
                {
                    switch (key)
                    {
                        case "0":
                            NavigationService.NavigateAsync(nameof(LoginPage) + "?login=0");
                            break;

                        case "1":
                            NavigationService.NavigateAsync(nameof(LoginPage) + "?login=1");
                            break;

                        case "2":
                            NavigationService.NavigateAsync(nameof(NotificationPage));
                            break;

                        case "3":
                            NavigationService.NavigateAsync(nameof(FAboutUsPage));
                            break;

                        case "4":
                            NavigationService.NavigateAsync(nameof(MyBookingPage));
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    var para = new NavigationParameters();
                    switch (key)
                    {
                        case "0":

                            para.Add("title", "Đăng ký");
                            para.Add("url", App.DataWinBanCaAndroid1.Urls.Register);
                            NavigationService.NavigateAsync(nameof(WebviewPage), para);
                            break;

                        case "1":

                            para.Add("title", "Đăng nhập");
                            para.Add("url", App.DataWinBanCaAndroid1.Urls.Login);
                            NavigationService.NavigateAsync(nameof(WebviewPage), para);
                            break;

                        case "2":
                            para.Add("title", "Khuyến mãi");
                            para.Add("url", App.DataWinBanCaAndroid1.Urls.Promotion);
                            NavigationService.NavigateAsync(nameof(WebviewPage), para);
                            break;

                        case "3":
                            para.Add("title", "Liên hệ CSKH");
                            para.Add("url", App.DataWinBanCaAndroid1.Urls.Support);
                            NavigationService.NavigateAsync(nameof(WebviewPage), para);
                            break;

                        case "4":
                            para.Add("title", "Đối tác đại lý");
                            para.Add("url", App.DataWinBanCaAndroid1.Urls.Afiliate);
                            NavigationService.NavigateAsync(nameof(WebviewPage), para);
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                _pageDialogService.DisplayAlertAsync("Notification", e.Message, "OK");
            }
        }
    }
}