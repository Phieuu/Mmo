﻿using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [Preserve(AllMembers = true)]
    public partial class TabbedLoginPage : ContentPage
    {
        public TabbedLoginPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when tab view selection items are changed.
        /// </summary>
        private void TabView_SelectionChanged(object sender, Syncfusion.XForms.TabView.SelectionChangedEventArgs e)
        {
            if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
            {
                if (e.Name == "Sign Up")
                {
                    this.frame.HeightRequest = 480;
                }
                else if (e.Name == "Login")
                {
                    this.frame.HeightRequest = 390;
                }
            }
        }
    }
}