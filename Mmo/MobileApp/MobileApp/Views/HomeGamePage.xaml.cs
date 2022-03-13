using System;
using MobileApp.ViewModels;
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
            var vm = BindingContext as HomeGamePageViewModel;
            if (vm != null)
            {
                vm.NavigationCommand.Execute(null);
            }
        }
    }
}
