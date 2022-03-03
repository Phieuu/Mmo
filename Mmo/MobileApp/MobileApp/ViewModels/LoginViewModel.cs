using MobileApp.Views;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private View _contentLoginPage;
        private string _userName;
        private string _passwd;
        private bool _isSavePasswd;
        private string _fullName;
        private string _phoneNumber;
        private string _nguoiGioiThieu;
        private IPageDialogService _pageDialogService;
        private bool _isLoading;

        public View ContentLoginPage
        {
            get => _contentLoginPage;
            set => SetProperty(ref _contentLoginPage, value);
        }

        public ICommand FunctionExecuteCommand { get; private set; }
        /// <summary>
        /// ten dung de dang nhap
        /// </summary>
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        /// <summary>
        /// mat khau
        /// </summary>
        public string Passwd
        {
            get => _passwd;
            set => SetProperty(ref _passwd, value);
        }
        /// <summary>
        /// luu mat khau tai khoan
        /// </summary>
        public bool IsSavePasswd
        {
            get => _isSavePasswd;
            set => SetProperty(ref _isSavePasswd, value);
        }
        /// <summary>
        /// ten nguoi dung
        /// </summary>
        public string FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value;
        }

        public string NguoiGioiThieu
        {
            get => _nguoiGioiThieu;
            set => SetProperty(ref _nguoiGioiThieu, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public LoginViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            FunctionExecuteCommand = new AsyncCommand<string>(async (key) => await FunctionExecute(key));
            Title = AppInfo.Name;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            try
            {
                IsLoading = true;
                if (parameters != null)
                {
                    if (parameters.ContainsKey("login"))
                    {
                        if (parameters.GetValue<string>("login") == "1")
                        {
                            ContentLoginPage = new LoginView();
                        }
                        else
                        {
                            ContentLoginPage = new SigupView();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task FunctionExecute(string key)
        {
            IsLoading = true;
            switch (key)
            {
                case "0":
                    await DoLogin(UserName, Passwd);
                    break;
                case "1":
                    ContentLoginPage = new SigupView();
                    break;
                case "2":
                    await DoSigup();
                    break;
                case "3":
                    ContentLoginPage = new LoginView();
                    break;
                default:
                    break;
            }

            IsLoading = false;
        }

        private async Task DoSigup()
        {
            try
            {
                if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(FullName) && !string.IsNullOrEmpty(PhoneNumber) && !string.IsNullOrEmpty(Passwd))
                {
                    await _pageDialogService.DisplayAlertAsync("Thông báo", "Tạo tài khoản thành công",
                        "OK");
                }
                else
                {
                    await _pageDialogService.DisplayAlertAsync("Thông báo", "Vui lòng điền đầy đủ thông tin",
                        "OK");
                }
            }
            catch (Exception e)
            {
                await _pageDialogService.DisplayAlertAsync("Thông báo",
                    "Lỗi phát sinh trong quá trình xử lý vui lòng thử lại",
                    "OK");
            }
            finally
            {
                UserName = Passwd = PhoneNumber = FullName = "";
            }
        }
        private async Task DoLogin(string user, string pwd)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Passwd))
                {
                    await NavigationService.NavigateAsync("/FMainPage", null, false, true);
                }
                else
                {
                    await _pageDialogService.DisplayAlertAsync("Thông báo", "Vui lòng điền đầy đủ thông tin",
                        "OK");
                }
            }
            catch (Exception e)
            {
                await _pageDialogService.DisplayAlertAsync("Thông báo", "Lỗi phát sinh trong quá trình xử lý vui long thử lại",
                    "OK");
            }
        }
    }
}