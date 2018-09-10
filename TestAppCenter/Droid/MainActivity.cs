using DBG = System.Diagnostics;
using Java.Interop;
using Android.Content;
using Android.App;
using Android.Widget;
using Android.OS;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace TestAppCenter.Droid
{
    [Activity(Label = "TestAppCenter", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            if (!AppCenter.Configured)
            {
                Push.PushNotificationReceived += (sender, e) =>
                {
                    // Add the notification message and title to the message
                    var summary = $"Push notification received:" +
                                        $"\n\tNotification title: {e.Title}" +
                                        $"\n\tMessage: {e.Message}";

                    // If there is custom data associated with the notification,
                    // print the entries
                    if (e.CustomData != null)
                    {
                        summary += "\n\tCustom data:\n";
                        foreach (var key in e.CustomData.Keys)
                        {
                            summary += $"\t\t{key} : {e.CustomData[key]}\n";
                        }
                    }

                    Toast.MakeText(this, summary, ToastLength.Long).Show();

                    // Send the notification summary to debug output
                    System.Diagnostics.Debug.WriteLine(summary);
                };
            }

            AppCenter.Start("b0887dc8-d325-492b-8494-35b4cb188fe1", typeof(Push));
            //Analytics.TrackEvent("Main Acitivity loaded - Android");

            // Get our button from the layout resource,
            // and attach an event to it

            var clickMeTextField = FindViewById<EditText>(Resource.Id.ClickMeTextField);
            Button clickMeButton = FindViewById<Button>(Resource.Id.ClickMeButton);
            Button viewMeButton = FindViewById<Button>(Resource.Id.ViewMeButton);


            clickMeButton.Click += delegate
            {

                clickMeTextField.Text = clickMeButton.Text;

                //Analytics.TrackEvent("Button Clicked from  - Android");
                //Crashes.GenerateTestCrash();
            };

            viewMeButton.Click += delegate
            {

                var viewMeIntent = new Intent(this, typeof(ViewMeActivity));
                viewMeIntent.PutExtra("ViewMeString", clickMeTextField.Text);
                StartActivity(viewMeIntent);

            };
        }
                
        [Export("viewMeBackdoor")]
        public void ViewMeBackdoor(string backdoorString)
        {

            DBG.Debug.WriteLine(backdoorString);

        }
    }
}

