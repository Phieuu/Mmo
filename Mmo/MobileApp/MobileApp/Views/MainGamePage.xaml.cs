using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using DateTime = System.DateTime;

namespace MobileApp.Views
{
    public partial class MainGamePage : ContentPage
    {
        private bool _turnOffMusic;
        public MainGamePage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                Vibration.Vibrate(TimeSpan.FromSeconds(3));
                if (_turnOffMusic)
                {
                    _turnOffMusic = false;
                    button.Text = "TẮT NHẠC";
                    button.BackgroundColor = Color.FromHex("#e15d16");
                }
                else
                {
                    _turnOffMusic = true;
                    button.Text = "BẬT NHẠC";
                    button.BackgroundColor = Color.Red;
                }
            }
        }

        private void Button_OnClicked1(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn != null)
            {
                if (btn.Text == "THÔNG TIN ỨNG DỤNG")
                {
                    var message = $"{AppInfo.Name}\nVersion: {AppInfo.Version}({AppInfo.BuildString})\n{DateTime.UtcNow.ToString("F")}";
                    App.Current.MainPage.DisplayAlert("Thông báo", message, "OK");
                }
                else if (btn.Text == "HỖ TRỢ 24/7")
                {
                    Browser.OpenAsync(App.DataNew88IOs.Urls.Support,
                        BrowserLaunchMode.SystemPreferred);
                }
            }
        }

        private void Button_OnClicked2(object sender, EventArgs e)
        {
            AppInfo.ShowSettingsUI();
        }
    }
}
