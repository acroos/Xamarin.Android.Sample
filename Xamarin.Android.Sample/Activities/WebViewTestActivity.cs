
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Webkit;

namespace Xamarin.Android.Sample
{
    [Activity (Label = "WebViewTestActivity")]
    public class WebViewTestActivity : BaseNavigationActivity
    {
        WebView _webView;
        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);

            SetContentView (Resource.Layout.WebViewTests);
            // Create your application here
            _webView = FindViewById<WebView>(Resource.Id.web_view);
            _webView.SetWebViewClient (new CustomClient ());
            _webView.LoadUrl ("http://espn.go.com/");
        }

        public override void OnBackPressed ()
        {
            if (_webView.CanGoBack()) {
                _webView.GoBack ();
            } else {
                base.OnBackPressed ();
            }
        }

        public void ForceBack()
        {
            base.OnBackPressed ();
        }

        public override bool OnCreateOptionsMenu (IMenu menu)
        {
            menu.Add ("Home");
            menu.GetItem (0).SetOnMenuItemClickListener (new GoHomeClickListener (this));
            return true;
        }
    }

    class CustomClient : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading (WebView view, string url)
        {
            view.LoadUrl (url);
            return false;
        }
    }

    class GoHomeClickListener : Java.Lang.Object, IMenuItemOnMenuItemClickListener
    {
        private readonly WebViewTestActivity _activity;
        public GoHomeClickListener(WebViewTestActivity activity)
        {
            _activity = activity;
        }

        public bool OnMenuItemClick (IMenuItem item)
        {
            _activity.ForceBack ();
            return false;
        }
    }
}

