using MobileApp.ViewModels;
using Xamarin.Forms;

namespace MobileApp.Views
{
    public partial class PlayGamePage : ContentPage
    {
        public PlayGamePage()
        {
            InitializeComponent();
        }

        private void VisualElement_OnUnfocused(object sender, FocusEventArgs e)
        {
            var vm = BindingContext as PlayGamePageViewModel;
            if (vm != null)
            {
                vm.SubmitCommand.Execute(vm.Answer);
            }
        }
    }
}
