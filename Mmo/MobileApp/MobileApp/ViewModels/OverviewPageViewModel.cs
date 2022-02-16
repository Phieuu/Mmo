using System;
using Prism.Navigation;
using Prism.Services.Dialogs;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class OverviewPageViewModel : ViewModelBase
    {
        private double _progress;
        private bool _isStartTimer;
        private double _progress4;
        private double _progress3;
        private double _progress2;
        private double _progress1;
        private double _progress5;
        private double _number2;
        private double _number1;
        private double _number3;
        private IDialogService _dialogService;

        public double Progress
        {
            get => _progress;
            set => SetProperty(ref _progress, value);
        }

        public double Progress4
        {
            get => _progress4;
            set => SetProperty(ref _progress4, value);
        }

        public double Progress3
        {
            get => _progress3;
            set => SetProperty(ref _progress3, value);
        }

        public double Progress2
        {
            get => _progress2;
            set => SetProperty(ref _progress2, value);
        }

        public double Progress1
        {
            get => _progress1;
            set => SetProperty(ref _progress1, value);
        }

        public double Progress5
        {
            get => _progress5;
            set => SetProperty(ref _progress5, value);
        }

        public double Number2
        {
            get => _number2;
            set => SetProperty(ref _number2, value);
        }

        public double Number1
        {
            get => _number1;
            set => SetProperty(ref _number1, value);
        }

        public double Number3
        {
            get => _number3;
            set => SetProperty(ref _number3, value);
        }

        public OverviewPageViewModel(INavigationService navigationService, IDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            Title = AppInfo.Name;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            _isStartTimer = true;
            var rd = new Random();
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                Progress = rd.Next(100);
                Progress1 = rd.Next(100);
                Progress2 = rd.Next(100);
                Progress3 = rd.Next(100);
                Progress4 = rd.Next(100);
                Progress5 = rd.Next(100);
                Number1 = rd.Next(100);
                Number2 = rd.Next(100);
                Number3 = rd.Next(100);
                return _isStartTimer;
            });
            if (parameters != null && parameters.ContainsKey("login"))
            {
                _dialogService.ShowDialog(nameof(ConfirmPasswdView));
            }
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
            _isStartTimer = false;
        }
    }
}
