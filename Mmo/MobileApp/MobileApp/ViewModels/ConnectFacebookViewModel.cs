using Prism.Mvvm;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class ConnectFacebookViewModel : BindableBase, IDialogAware
    {
        private string _email;
        private string _passwd;
        public event Action<IDialogParameters> RequestClose;
        private IPageDialogService _pageDialogService;
        private string _baseUrl= "https://m.facebook.com/";
        private bool _isShowWebView = true;

        public bool IsShowWebView
        {
            get => _isShowWebView;
            set => SetProperty(ref _isShowWebView, value);
        }

        public string BaseUrl
        {
            get => _baseUrl;
            set => SetProperty(ref _baseUrl, value);
        }

        public ICommand LogInCommand { get; private set; }
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Passwd
        {
            get => _passwd;
            set => SetProperty(ref _passwd, value);
        }

        public ConnectFacebookViewModel(IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
            LogInCommand = new AsyncCommand(LogInCommandExcute);
        }

        private async Task LogInCommandExcute()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Passwd))
            {
                // thong bao loi
                await _pageDialogService.DisplayAlertAsync("Notification", "Error", "OK");
            }
            else
            {
                // dang nhap

                Preferences.Clear();
                Preferences.Set(nameof(Email), "Email");
                Preferences.Set(nameof(Passwd), "Passwd");
                
                IsShowWebView = false;

                await _pageDialogService.DisplayAlertAsync("Notification", "Error", "OK");
            }
        }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
            MessagingCenter.Unsubscribe<App>(this, "Cookie");
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            MessagingCenter.Subscribe<App>(this, "Cookie", async (app) =>
            {
                RequestClose(new DialogParameters("?login=1"));
            });
        }
    }
}