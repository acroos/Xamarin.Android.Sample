using Android.App;
using Android.OS;
using Android.Views;

namespace Xamarin.Android.Sample
{
    [Activity (Label = "TextTestActivity")]
    public class TextTestActivity : BaseNavigationActivity
    {
        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.TextTests);
            ActionBar.SetHomeButtonEnabled (true);
            ActionBar.SetDisplayHomeAsUpEnabled (true);
        }

        public override bool OnOptionsItemSelected (IMenuItem item)
        {
            switch(item.ItemId)
            {
            // Home button
            case 16908332:
                Finish ();
                return true;
            default:
                return base.OnOptionsItemSelected (item);
            }
        }
    }
}

