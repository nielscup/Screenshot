using System;
using UIKit;
using Plugin.Screenshot;
using Plugin.ShareFile;
using CoreAnimation;
using CoreGraphics;

namespace ScreenshotTest.iOS.Views
{
    public partial class MainViewController : UIViewController
    {
        string screenshotPath;

        public MainViewController() : base("MainViewController", null) { }
                
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            TakeScreenshotButton.TouchUpInside += TakeScreenshotButton_TouchUpInside;
            ShareScreenshotButton.TouchUpInside += ShareScreenshotButton_TouchUpInside;
            ShareScreenshotButton.Hidden = true;

            SetBackground();
        }
                
        void TakeScreenshotButton_TouchUpInside(object sender, EventArgs e)
        {
            TakeScreenshot();
        }

        void ShareScreenshotButton_TouchUpInside(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(screenshotPath))
                return;

            CrossShareFile.Current.ShareLocalFile(screenshotPath);
        }

        void TakeScreenshot()
        {
            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            screenshotPath = System.IO.Path.Combine(documentsDirectory, "screenshot.jpg");

            if (CrossScreenshot.Current.TakeScreenshot(screenshotPath, null))
            {
                ScreenshotImage.Image = new UIImage(screenshotPath);
                ShareScreenshotButton.Hidden = false;
            }
        }

        void SetBackground()
        {
            var gradient = new CAGradientLayer();
            gradient.Frame = View.Bounds;
            gradient.NeedsDisplayOnBoundsChange = true;
            gradient.MasksToBounds = true;
            gradient.Colors = new CGColor[] { UIColor.Black.CGColor, UIColor.DarkGray.CGColor };
            View.Layer.InsertSublayer(gradient, 0);
        }
    }
}