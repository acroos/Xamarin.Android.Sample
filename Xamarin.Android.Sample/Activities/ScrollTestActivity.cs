
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
    [Activity (Label = "ScrollTestActivity")]
    public class ScrollTestActivity : ListActivity
    {
        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ScrollTests);
            var items = new string[30];
            for(int i=0; i<30; i++) {
                items [i] = i != 22 ? string.Format ("Item{0}", i+1) : "Potato";
            }
            ListAdapter = new ArrayAdapter<String> (this, global::Android.Resource.Layout.SimpleListItem1, items);
        }
    }
}

