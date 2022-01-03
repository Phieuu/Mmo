using MobileApp.Models;
using Prism.Navigation;
using System.Collections.Generic;
using System.Windows.Input;

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
                Title = "a",
            },
            new OnBoardingModel()
            {
                Id = 1,
                ImgName = "1.json",
                Title = "b",
            },
            new OnBoardingModel()
            {
                Id = 2,
                ImgName = "2.json",
                Title = "c",
            },
            new OnBoardingModel()
            {
                Id = 3,
                ImgName = "3.json",
                Title = "d",
            },
            new OnBoardingModel()
            {
                Id = 4,
                ImgName = "4.json",
                Title = "e",
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
            
        }

    }
}
