using MobileApp.Models;
using Prism.Navigation;
using System.Collections.Generic;
using System.Windows.Input;
using MobileApp.Views;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class OnBoardingPageViewModel : ViewModelBase
    {
        private List<OnBoardingModel> _onBoardingModels=new List<OnBoardingModel>()
        {
            new OnBoardingModel()
            {
                Id = 0,
                ImgName = "0.json",
                Title = "On The Way To Success, There Is No Trace Of Lazy Men.",
            },
            new OnBoardingModel()
            {
                Id = 1,
                ImgName = "1.json",
                Title = "If I Fail, I Try Again And Again, And Again.",
            },
            new OnBoardingModel()
            {
                Id = 2,
                ImgName = "2.json",
                Title = "Studying Is Not About Time. It’s About Effort.",
            },
            new OnBoardingModel()
            {
                Id = 3,
                ImgName = "3.json",
                Title = "Once You Stop Learning, You Will Start Dying.",
            },
            new OnBoardingModel()
            {
                Id = 4,
                ImgName = "4.json",
                Title = "You Learn Something Everyday If You Pay Attention.",
            },
        };

        public ICommand GetStartedCommad { get; set; }
        public List<OnBoardingModel> OnBoardingModels
        {
            get => _onBoardingModels;
            set => SetProperty(ref _onBoardingModels, value);
        }

        public OnBoardingPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            GetStartedCommad = new Command(GetStartedCommadExcute);
        }

        private void GetStartedCommadExcute()
        {
            NavigationService.NavigateAsync(nameof(LoginPage));
        }
    }
}
