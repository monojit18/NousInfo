
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBG = System.Diagnostics;
using Java.Interop;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace TestAppCenter.Droid
{
    [Activity(Label = "ViewMeActivity")]
    public class ViewMeActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ViewMe);

            ViewMeString = Intent.GetStringExtra("ViewMeString");

            var doneButton = FindViewById<Button>(Resource.Id.DoneButton);
            doneButton.Click += (object sender, EventArgs e) =>
            {

                Finish();

                Analytics.TrackEvent("ViewMeButton clicked", new Dictionary<string, string>()
                {

                    {"ViewMeString", ViewMeString}

                });

            };

            var viewMeTextField = FindViewById<EditText>(Resource.Id.ViewMeTextField);
            viewMeTextField.Text = ViewMeString;


        }

        public string ViewMeString { get; set; }

        [Export("ViewMeBackdoor")]
        public void ViewMeBackdoor(string backdoorString)
        {

            DBG.Debug.WriteLine($"ViewMeActivity:{backdoorString}");

        }

    }
}
