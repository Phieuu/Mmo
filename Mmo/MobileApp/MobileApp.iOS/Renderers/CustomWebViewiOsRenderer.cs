using System.Linq;
using MobileApp.Controls;
using MobileApp.iOS.Renderers;
using WebKit;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomWebViewRenderer), typeof(CustomWebViewiOsRenderer))]
namespace MobileApp.iOS.Renderers
{
    public class CustomWebViewiOsRenderer : WkWebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                NavigationDelegate = new CookieNavigationDelegate();
            }
        }
    }
    public class CookieNavigationDelegate : WKNavigationDelegate
    {
        private bool _hasCookie;
        public override async void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
        {
            if (!_hasCookie)
            {
                //Lấy cookie tại đây
                webView.Configuration.WebsiteDataStore.HttpCookieStore.GetAllCookies(async (cookies) =>
                {
                    var data = string.Empty;
                    if (cookies != null && cookies.Any())
                    {
                        foreach (var item in cookies)
                        {
                            data += $"{item.Name}={item.Value};";
                        }

                        if (data.Contains("c_user="))
                        {
                            _hasCookie = true;
                            // to do
                            Preferences.Set("Cookie", data);
                            MessagingCenter.Send<App>((App)Xamarin.Forms.Application.Current, "Cookie");
                        }
                        // to do get cookie
                    }
                });
            }


            //if (_hasCookie)
            //{
            //    var jsData = await webView.EvaluateJavaScriptAsync("document.body.innerHTML");
            //    var html = jsData.ToString();
            //    if (!string.IsNullOrWhiteSpace(html))
            //    {
            //       // to do
            //    }
            //}
        }
    }
}