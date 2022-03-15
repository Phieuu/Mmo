using Prism.Mvvm;

namespace MobileApp.Models
{
    public class UpdateWinBanCaAndroid1Model : BindableBase
    {
        private bool _isUpdate;

        public bool IsUpdate
        {
            get => _isUpdate;
            set => SetProperty(ref _isUpdate, value);
        }

        public string AppName { get; set; }
        public AppUrlModel Urls { get; set; } = new AppUrlModel();
    }
}