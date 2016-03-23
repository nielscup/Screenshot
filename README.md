# Screenshot Plugin for Xamarin

Simple way to crop an image in Xamarin.iOS and Xamarin.Android

#### Setup
* Coming soon to NuGet
* Or run the following command to create a nuget package:
```
nuget pack Plugin.Screenshot.nuspec
```

**Supports**
* Xamarin.iOS (Unified)
* Xamarin.Android

### API Usage

Call **CrossScreenshot.Current** from any project or PCL to gain access to APIs.

**iOS**
```
    void TakeScreenshot()
    {
        var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        var screenshotPath = System.IO.Path.Combine(documentsDirectory, "screenshot.jpg");

        if (CrossScreenshot.Current.TakeScreenshot(screenshotPath, null))
        {
            // Set UIImageView to show the screenshot
            screenshotImage.Image = new UIImage(screenshotPath);
        }
    }
```

**Android**
```
    void TakeScreenshot()
    {
        var screenshotPath = Android.OS.Environment.ExternalStorageDirectory.ToString() + "/screenshot.jpg";

        if (CrossScreenshot.Current.TakeScreenshot(screenshotPath, this))
        {
            // Set ImageView to show the screenshot
            var screenshotUri = Android.Net.Uri.FromFile(new Java.IO.File(screenshotPath));
            screenshotImage.SetImageURI(null);
            screenshotImage.SetImageURI(screenshotUri);
        }
    }
```