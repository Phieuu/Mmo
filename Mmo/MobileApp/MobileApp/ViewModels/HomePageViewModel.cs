using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MobileApp.Views;
using Prism.Navigation;
using Prism.Services;
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
                if (App.DataApp.IsUpdate)
                {
                    switch (key)
                    {
                        case "0":
                            NavigationService.NavigateAsync(nameof(MainPage));
                            break;

                        case "1":
                            NavigationService.NavigateAsync(nameof(MainPage));
                            break;

                        case "2":
                            NavigationService.NavigateAsync(nameof(MainPage));
                            break;

                        case "3":
                            NavigationService.NavigateAsync(nameof(MainPage));
                            break;

                        case "4":
                            NavigationService.NavigateAsync("/NavigationPage/MainPage");
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    switch (key)
                    {
                        case "0":
                            Browser.OpenAsync(App.DataApp.Urls.Register, BrowserLaunchMode.SystemPreferred);
                            break;

                        case "1":
                            Browser.OpenAsync(App.DataApp.Urls.Login, BrowserLaunchMode.SystemPreferred);
                            break;

                        case "2":
                            Browser.OpenAsync(App.DataApp.Urls.Promotion, BrowserLaunchMode.SystemPreferred);
                            break;

                        case "3":
                            Browser.OpenAsync(App.DataApp.Urls.Support, BrowserLaunchMode.SystemPreferred);
                            break;

                        case "4":
                            Browser.OpenAsync(App.DataApp.Urls.Afiliate, BrowserLaunchMode.SystemPreferred);
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