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

namespace Xamarin.Android.Sample
{
    [Activity (Label = "TapTestActivity")]
    public class TapTestActivity : BaseNavigationActivity
    {
        protected override void OnCreate (Bundle savedInstanceState)
        {
            bool pageLoadSelection = true;
            base.OnCreate (savedInstanceState);

            var doubleTapDetector = new GestureDetector (this, new DoubleTapGestureListener ());
            doubleTapDetector.DoubleTap += (sender, e) => ShowAlert ("DoubleTap Alert");
            // Create your application here
            SetContentView(Resource.Layout.TapTests);
            ActionBar.SetHomeButtonEnabled (true);
            ActionBar.SetDisplayHomeAsUpEnabled (true);

            Button tapButton = FindViewById<Button> (Resource.Id.tap_test_tap_button);
            Button doubleTapButton = FindViewById<Button> (Resource.Id.tap_test_double_tap_button);
            Button longPressButton = FindViewById<Button> (Resource.Id.tap_test_long_press_button);
            Spinner spinner = FindViewById<Spinner> (Resource.Id.tap_test_spinner);

            var adapter = ArrayAdapter.CreateFromResource (this, Resource.Array.tap_test_spinner_array, global::Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource (global::Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
                
            tapButton.Click += (sender, e) => ShowAlert ("Tap Alert");
            doubleTapButton.Touch += (sender, e) => doubleTapDetector.OnTouchEvent (e.Event);
            longPressButton.LongClick += (sender, e) => ShowAlert ("LongPress Alert");
            spinner.ItemSelected += (sender, e) => {
                if (!pageLoadSelection) {
                    ShowAlert("You chose " + spinner.GetItemAtPosition(e.Position));
                }
                pageLoadSelection = false;
            };
        }

        public override bool OnOptionsItemSelected (IMenuItem item)
        {
            switch(item.ItemId)
            {
            // Home button
            case global::Android.Resource.Id.Home:
                Finish ();
                return true;
            default:
                return base.OnOptionsItemSelected (item);
            }
        }

        private void ShowAlert(string title, string positiveBtnText = "OK", string negativeBtnText = "Cancel")
        {
            var alert = new AlertDialog.Builder (this);

            alert.SetTitle (title);
            alert.SetPositiveButton (positiveBtnText, ((object sender, DialogClickEventArgs e) => {
                Toast.MakeText(this, string.Format("Clicked '{0}'", positiveBtnText), ToastLength.Short);
                var senderAlert = (AlertDialog)sender;
                senderAlert.Dismiss();
            }));

            alert.SetNegativeButton (negativeBtnText, ((object sender, DialogClickEventArgs e) => {
                Toast.MakeText(this, string.Format("Clicked '{0}'", negativeBtnText), ToastLength.Short);
                var senderAlert = (AlertDialog)sender;
                senderAlert.Dismiss();
            }));

            RunOnUiThread (() => alert.Show());
        }

        public override bool OnCreateOptionsMenu (IMenu menu)
        {
            var strings = new [] {
                "this",
                "that",
                "the other",
                "alfredo sauce",
                "hi josh and john"
            };

            for(int i=0; i<strings.Length; i++) {
                menu.Add (strings [i]);
            }
            return true;
        }
    }

    class DoubleTapGestureListener : GestureDetector.SimpleOnGestureListener
    {
        public override bool OnDown(MotionEvent e)
        {
            return true;
        }

        public override bool OnDoubleTap (MotionEvent e)
        {
            return true;
        }
    }
}

