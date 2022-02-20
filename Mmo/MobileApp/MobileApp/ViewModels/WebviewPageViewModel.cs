using Prism.Navigation;

namespace MobileApp.ViewModels
{
    public class WebviewPageViewModel : ViewModelBase
    {
        private string _urlApp;

        public string UrlApp
        {
            get => _urlApp;
            set => SetProperty(ref _urlApp, value);
        }

        public WebviewPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Title = parameters.GetValue<string>("title");
            UrlApp = parameters.GetValue<string>("url");
        }
    }
}