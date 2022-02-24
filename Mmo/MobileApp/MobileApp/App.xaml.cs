using MobileApp.FakeModules.ViewModels.AboutUs;
using MobileApp.FakeModules.ViewModels.HelperUs;
using MobileApp.FakeModules.ViewModels.Home;
using MobileApp.FakeModules.ViewModels.InviteFriend;
using MobileApp.FakeModules.ViewModels.Main;
using MobileApp.FakeModules.ViewModels.MyBooking;
using MobileApp.FakeModules.ViewModels.MyProfile;
using MobileApp.FakeModules.ViewModels.Notification;
using MobileApp.FakeModules.ViewModels.TermsCondition;
using MobileApp.FakeModules.Views.AboutUs;
using MobileApp.FakeModules.Views.HelperUs;
using MobileApp.FakeModules.Views.Home;
using MobileApp.FakeModules.Views.InviteFriend;
using MobileApp.FakeModules.Views.Main;
using MobileApp.FakeModules.Views.MyBooking;
using MobileApp.FakeModules.Views.Notification;
using MobileApp.FakeModules.Views.Profile;
using MobileApp.FakeModules.Views.TermsCondition;
using MobileApp.Models;
using MobileApp.Services.Database;
using MobileApp.Services.RestSharp;
using MobileApp.Services.Telegram;
using MobileApp.ViewModels;
using MobileApp.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class App
    {
        public static UpdateOle777K8MaModel DataOle777K8Ma = new UpdateOle777K8MaModel();
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTU3NjUyQDMxMzkyZTM0MmUzMFlSRWdodlB5cjRaVktPYTJ4QllmU2l1N1VWWUxXS1ZHQlVYTHNpVmlpcHM9");

            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<TermsConditionPage, TermsConditionViewModel>();
            containerRegistry.RegisterForNavigation<MyProfilePage, MyProfileViewModel>();
            containerRegistry.RegisterForNavigation<NotificationPage, NotificationViewModel>();
            containerRegistry.RegisterForNavigation<MyBookingPage, MyBookingViewModel>();
            containerRegistry.RegisterForNavigation<FMainPage, FMainViewModel>();
            containerRegistry.RegisterForNavigation<InviteFriendPage, InviteFriendViewModel>();
            containerRegistry.RegisterForNavigation<FHomePage, FHomeViewModel>();
            containerRegistry.RegisterForNavigation<HelperUsPage, HelperUsViewModel>();
            containerRegistry.RegisterForNavigation<FAboutUsPage, AboutUsViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();

            containerRegistry.Register<IFirebaseDatabaseService, FirebaseDatabaseService>();
            containerRegistry.Register<IRestSharpService, RestSharpService>();
            containerRegistry.Register<ITelegramService, TelegramService>();
            containerRegistry.RegisterForNavigation<WebviewPage, WebviewPageViewModel>();
            containerRegistry.RegisterForNavigation<Ole777ProPage, Ole777ProPageViewModel>();
        }
    }
}