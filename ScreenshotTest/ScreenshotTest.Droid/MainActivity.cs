using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.Screenshot;

namespace ScreenshotTest.Droid
{
    [Activity(Label = "ScreenshotTest.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ImageView screenshotImage;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            screenshotImage = FindViewById<ImageView>(Resource.Id.screenshotImage);

            button.Click += delegate 
            {
                TakeScreenshot();
            }; 
        }

        void TakeScreenshot()
        {
            var screenshotPath = Android.OS.Environment.ExternalStorageDirectory.ToString() + "/screenshot.jpg";

            if (CrossScreenshot.Current.TakeScreenshot(screenshotPath, this))
            {
                var screenshotUri = Android.Net.Uri.FromFile(new Java.IO.File(screenshotPath));
                screenshotImage.SetImageURI(null);
                screenshotImage.SetImageURI(screenshotUri);
            }
        }
    }
}

