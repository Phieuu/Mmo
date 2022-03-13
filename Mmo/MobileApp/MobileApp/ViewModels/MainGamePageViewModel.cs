using System.Threading.Tasks;
using System.Windows.Input;
using MobileApp.Views;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;

namespace MobileApp.ViewModels
{
    public class MainGamePageViewModel : ViewModelBase
    {
        public ICommand PlayGameCommand { get; private set; }
        public ICommand RegisterCommand { get; private set; }
        public ICommand LoginCommand { get; private set; }
        public MainGamePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            PlayGameCommand = new AsyncCommand(ExcutePlayGameCommand);
            RegisterCommand = new AsyncCommand(ExcuteRegisterCommand);
            LoginCommand = new AsyncCommand(ExcuteLoginCommand);
            Title = AppInfo.Name;
        }

        private async Task ExcuteLoginCommand()
        {
            if (App.DataWinBanCaAndroid1.IsUpdate)
            {
                await NavigationService.NavigateAsync(nameof(LoginPage) + "?login=0");
                return;
            }
            var para = new NavigationParameters();
            para.Add("title", "Đăng nhập");
            para.Add("url", App.DataWinBanCaAndroid1.Urls.Login);
            await NavigationService.NavigateAsync(nameof(WebviewPage), para);

        }

        private async Task ExcuteRegisterCommand()
        {
            if (App.DataWinBanCaAndroid1.IsUpdate)
            {
                await NavigationService.NavigateAsync(nameof(LoginPage) + "?login=1");
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
