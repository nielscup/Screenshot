using Foundation;
using Plugin.Screenshot.Abstractions;
using System;
using UIKit;


namespace Plugin.Screenshot
{
    /// <summary>
    /// Implementation for Screenshot
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

                var screenshot = UIScreen.MainScreen.Capture();
                return SaveScreenshot(screenshot, screenshotPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Plugin.Screenshot.TakeScreenshot: {0}", e.Message);
            }

            return false;
        }

        private bool SaveScreenshot(UIImage screenshot, string screenshotPath)
        {
            try
            {
                NSData imgData = screenshot.AsJPEG();
                NSError err = null;

                if (imgData.Save(screenshotPath, false, out err))
                {
                    Console.WriteLine("Screenshot saved as " + screenshotPath);
                    return true;
                }
                else
                {
                    Console.WriteLine("Screenshot NOT saved as " + screenshotPath + " because" + err.LocalizedDescription);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Plugin.Screenshot.SaveScreenshot: {0}", ex.Message);
            }

            return false;
        }
    }
}