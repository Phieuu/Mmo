using System.Threading.Tasks;
using System.Windows.Input;
using MobileApp.Views;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;

namespace MobileApp.ViewModels
{
    public class MainGamePageViewModel : ViewModelBase
    {
        public ICommand PlayGameCommand { get; private set; }
        public MainGamePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            PlayGameCommand = new AsyncCommand(ExcutePlayGameCommand);
        }

        private Task ExcutePlayGameCommand()
        {
            return NavigationService.NavigateAsync(nameof(PlayGamePage));
        }
    }
}
