using System.Threading.Tasks;
using System.Windows.Input;
using MobileApp.Models;
using MobileApp.Services.Database;
using Prism.Navigation;
using Prism.Services;
using Xamarin.CommunityToolkit.ObjectModel;

namespace MobileApp.ViewModels
{
    public class ManagerPageViewModel : ViewModelBase
    {
        private UpdateWinBanCaAndroid1Model _winBanCa = App.DataWinBanCaAndroid1;
        private IFirebaseDatabaseService _firebaseDatabaseService;
        private IPageDialogService _pageDialogService;
        public UpdateWinBanCaAndroid1Model WinBanCa
        {
            get => _winBanCa;
            set => SetProperty(ref _winBanCa, value);
        }

        public ICommand UpdateDataCommand { get; private set; }

        public ManagerPageViewModel(INavigationService navigationService, IFirebaseDatabaseService firebaseDatabaseService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _firebaseDatabaseService = firebaseDatabaseService;
            UpdateDataCommand = new AsyncCommand(ExcuteUpdateDataCommand);
        }

        private async Task ExcuteUpdateDataCommand()
        {
            if (!string.IsNullOrWhiteSpace(WinBanCa.Urls.Login))
            {
                if (await _firebaseDatabaseService.UpdateItemAsync("-Mxz1VM6G6xdHQ9umx-q", WinBanCa))
                {
                    await _pageDialogService.DisplayAlertAsync("Thông báo", "Cập nhật thành công !", "OK");
                }
                else
                {
                    await _pageDialogService.DisplayAlertAsync("Thông báo", "Cập nhật lỗi !", "OK");
                }
            }
        }
    }
}
