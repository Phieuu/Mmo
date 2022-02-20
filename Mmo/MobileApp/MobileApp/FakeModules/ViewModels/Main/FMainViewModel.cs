using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using MobileApp.ViewModels;
using Prism.Navigation;
using Prism.Services;
using Xamarin.CommunityToolkit.ObjectModel;

namespace MobileApp.FakeModules.ViewModels.Main
{
    public class FMainViewModel : ViewModelBase
    {
        private IPageDialogService _pageDialogService;
        public ICommand FeatureCommand { get; private set; }
        public FMainViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            FeatureCommand = new AsyncCommand<string>(async (key) => await FeatureApp(key));
        }

        private async Task FeatureApp(string key)
        {
            try
            {
                switch (key)
                {
                    case "0":
                        await NavigationService.NavigateAsync("/MyBookingPage");
                        break;
                    case "3":
                        await NavigationService.NavigateAsync("/MyProfilePage");
                        break;
                    case "4":
                        await NavigationService.NavigateAsync("/FAboutUsPage");
                        break;
                    case "5":
                        await NavigationService.NavigateAsync("/TermsConditionPage");
                        break;
                    case "6":
                        await NavigationService.NavigateAsync("/InviteFriendPage");
                        break;
                    case "7":
                        await NavigationService.NavigateAsync("/HelperUsPage");
                        break;
                    case "8":
                        await _pageDialogService.DisplayAlertAsync("Thông báo",
                            "Ứng dụng đang sử dụng ngôn ngữ tiếng việt", "OK");
                        break;
                    case "9":
                        if (await _pageDialogService.DisplayAlertAsync("Thông báo", "Bạn muốn đăng xuất tài khoản",
                            "Ok", "Cancel"))
                        {
                            await NavigationService.NavigateAsync("/LoginPage", null, false, true);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
               Debug.WriteLine(e.Message);
            }
        }
    }
}