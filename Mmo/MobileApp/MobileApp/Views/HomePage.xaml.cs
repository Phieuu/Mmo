using System;
using Syncfusion.XForms.PopupLayout;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            popupLayout.ShowRelativeToView(btnSelectLangue, RelativePosition.AlignBottom, 0, 0);
        }

        private void TapGestureRecognizer_OnTapped_Close(object sender, EventArgs e)
        {
            popupLayout.IsOpen = false;
        }
    }
}