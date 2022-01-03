using Android.Content;
using Android.Webkit;
using MobileApp.Controls;
using MobileApp.Droid.Renderers;
using System;
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
                Control.SetWebViewClient(new CookieWebview());
            }
        }
    }
    public class CookieWebview : WebViewClient
    {
        private bool _hasCookie;
        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);

            if (!_hasCookie)
            {
                //lấy cookie tại đây
                var cookieHeader = CookieManager.Instance?.GetCookie(url)?.Replace(" ", "");
                if (!string.IsNullOrWhiteSpace(cookieHeader) && cookieHeader.Contains("c_user="))
                {
                   // to do
                }
            }

            if (_hasCookie)
            {
                view.EvaluateJavascript("document.body.innerHTML", new JavascriptCallback(html =>
                {
                    if (html != null)
                    {
                       // to do
                    }
                }));
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