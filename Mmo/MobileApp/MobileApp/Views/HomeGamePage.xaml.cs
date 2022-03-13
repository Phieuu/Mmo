using System;
using Xamarin.Forms;

namespace MobileApp.Views
{
    public partial class HomeGamePage : ContentPage
    {
        public HomeGamePage()
        {
            InitializeComponent();
        }

        private void AnimationView_OnOnFinishedAnimation(object sender, EventArgs e)
        {
            animationView.Animation = "rocket.josn";
        }
    }
}
