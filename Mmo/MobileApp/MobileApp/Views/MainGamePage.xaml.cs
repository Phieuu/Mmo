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
            var message = $"Đuổi hình bắt chữ\nVersion: {AppInfo.Version}({AppInfo.BuildString})\n{DateTime.UtcNow.ToString("F")}";
            App.Current.MainPage.DisplayAlert("Thông báo", message, "OK");
        }

        private void Button_OnClicked2(object sender, EventArgs e)
        {
            AppInfo.ShowSettingsUI();
        }
    }
}
