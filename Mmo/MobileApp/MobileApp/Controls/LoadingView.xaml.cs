using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingView : ContentView
    {
        public LoadingView()
        {
            InitializeComponent();
        }
    }
}