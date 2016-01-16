using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;

namespace Xamarin.Android.Sample
{
    [Activity (Label = "Xamarin.Android.Sample", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            Button btnGotoTapTests = FindViewById<Button> (Resource.Id.btn_goto_tap_tests);
            Button btnGotoTextTests = FindViewById<Button> (Resource.Id.btn_goto_text_tests);
            Button btnGotoScrollTests = FindViewById<Button> (Resource.Id.btn_goto_scroll_tests);
            Button btnGotoSwipeTests = FindViewById<Button> (Resource.Id.btn_goto_swipe_tests);
            Button btnGotoWebViewTests = FindViewById<Button> (Resource.Id.btn_goto_webview_tests);

            btnGotoTapTests.Click += (sender, e) => GotoActivity (typeof(TapTestActivity));

            btnGotoTextTests.Click += (sender, e) => GotoActivity (typeof(TextTestActivity));

            btnGotoScrollTests.Click += (sender, e) => GotoActivity (typeof(ScrollTestActivity));

            btnGotoSwipeTests.Click += (sender, e) => GotoActivity (typeof(SwipeTestActivity));

            btnGotoWebViewTests.Click += (sender, e) => GotoActivity (typeof(WebViewTestActivity));
        }

        private void GotoActivity(Type activityType)
        {
            var intent = new Intent (this, activityType);
            StartActivity (intent);
        }
    }
}


