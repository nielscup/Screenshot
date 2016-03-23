using Plugin.Screenshot.Abstractions;
using System;
using Android.Content;
using Android.App;
using Android.Database;
using Android.Graphics;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Android.Views;

[assembly: Permission(Name = "android.permission.READ_EXTERNAL_STORAGE")]
[assembly: Permission(Name = "android.permission.WRITE_EXTERNAL_STORAGE")]
namespace Plugin.Screenshot
{
  /// <summary>
  /// Implementation for Feature
  /// </summary>
  public class ScreenshotImplementation : IScreenshot
  {
      public bool TakeScreenshot(string screenshotPath, object screen)
      {
          try
          {
              if (string.IsNullOrWhiteSpace(screenshotPath))
              {
                  Console.WriteLine("Plugin.Screenshot.TakeScreenshot: screenshotPath not set");
                  return false;
              }

              Activity activity;
              if (screen is Activity)
              {
                  activity = (Activity)screen;
              }
              else
              {
                  Console.WriteLine("Plugin.Screenshot.TakeScreenshot: screen should be of type Activity");
                  return false;
              }
              
              // create bitmap screen capture
              View v1 = activity.Window.DecorView.RootView;
              
              v1.DrawingCacheEnabled = true;
              Bitmap bitmap = Bitmap.CreateBitmap(v1.DrawingCache);
              v1.DrawingCacheEnabled = false;

              Java.IO.File imageFile = new Java.IO.File(screenshotPath);

              if (!imageFile.Exists())
                  imageFile.CreateNewFile();
                            
              var screenshotUri = Android.Net.Uri.FromFile(imageFile);
              using (var outputStream = Android.App.Application.Context.ContentResolver.OpenOutputStream(screenshotUri))
              {
                  int quality = 100;
                  bitmap.Compress(Bitmap.CompressFormat.Jpeg, quality, outputStream);
                  outputStream.Flush();
                  outputStream.Close();
                  return true;
              }
          }
          catch (Exception e)
          {  
              Console.WriteLine("Exception Plugin.Screenshot.TakeScreenshot: {0}", e.Message);
          }

          return false;
      }
  }
}