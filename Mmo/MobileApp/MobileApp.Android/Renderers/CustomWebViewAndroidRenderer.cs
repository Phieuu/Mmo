using Android.Content;
using Android.Webkit;
using MobileApp.Controls;
using MobileApp.Droid.Renderers;
using System;
using Android.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using WebView = Android.Webkit.WebView;

[assembly: ExportRenderer(typeof(CustomWebViewRenderer), typeof(CustomWebViewAndroidRenderer))]
namespace MobileApp.Droid.Renderers
{
    public class CustomWebViewAndroidRenderer : WebViewRenderer
    {
        public CustomWebViewAndroidRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                Control.Settings.SetSupportMultipleWindows(true);
                Control.SetWebViewClient(new CookieWebview());
            }
        }
    }
    public class CookieWebview : WebViewClient
    {
        private bool _hasCookie;
        public override void OnReceivedSslError(WebView? view, SslErrorHandler? handler, SslError? error)
        {
            handler.Proceed();
        }

        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);

            //lấy cookie tại đây
            var cookieHeader = CookieManager.Instance?.GetCookie(url)?.Replace(" ", "");
            if (!string.IsNullOrWhiteSpace(cookieHeader))
            {
                // to do
            }

            if (url.Contains("http://"))
            {
                url = url.Replace("http://", "https://");
                view.LoadUrl(url);
            }
        }
    }
    internal class JavascriptCallback : Java.Lang.Object, IValueCallback
    {
        public JavascriptCallback(Action<string> callback)
        {
            _callback = callback;
        }

        private Action<string> _callback;
        public void OnReceiveValue(Java.Lang.Object value)
        {
            _callback?.Invoke(Convert.ToString(value));
        }
    }
}