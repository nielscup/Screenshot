using CoreAnimation;
using CoreGraphics;
using Plugin.Screenshot;
using Plugin.ShareFile;
using System;
using UIKit;

namespace ScreenshotTest.iOS
{
    public partial class ViewController : UIViewController
    {
        UIButton _takeScreenshotButton;
        UIButton _shareScreenshotButton;
        UIImageView _screenshotImage;
        string _screenshotPath;

        public ViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            SetBackground();

            _takeScreenshotButton = AddButton("Take Screenshot");
            _takeScreenshotButton.TouchUpInside += _takeScreenshotButton_TouchUpInside;

            _screenshotImage = AddImage(400, 400);

            _shareScreenshotButton = AddButton("Share screenshot");
            _shareScreenshotButton.Hidden = true;
            _shareScreenshotButton.TouchUpInside += _shareScreenshotButton_TouchUpInside;
        }

        void _takeScreenshotButton_TouchUpInside(object sender, EventArgs e)
        {
            TakeScreenshot();
        }

        void _shareScreenshotButton_TouchUpInside(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_screenshotPath))
                return;

            CrossShareFile.Current.ShareLocalFile(_screenshotPath);
        }

        void TakeScreenshot()
        {
            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            _screenshotPath = System.IO.Path.Combine(documentsDirectory, "screenshot.jpg");

            if (CrossScreenshot.Current.TakeScreenshot(_screenshotPath, null))
            {
                _screenshotImage.Image = new UIImage(_screenshotPath);
                _shareScreenshotButton.Hidden = false;
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

        #region ui controls

        int yPos = 30;
        int xPos;
        const int defaultSize = 300;

        public UIImageView AddImage(int height, int width)
        {
            var x = (int)(View.Bounds.Width - width) / 2;
            var image = new UIImageView(GetFrame(height, width, x));
            image.ContentMode = UIViewContentMode.ScaleAspectFit;
            Add(image);

            yPos += height;

            return image;
        }

        private UIButton AddButton(string title, int width = defaultSize, bool behindPreviousControl = false)
        {
            var height = 36;

            if (behindPreviousControl)
                yPos -= height;
            else
                xPos = (int)(View.Bounds.Width - width) / 2;

            var button = new UIButton(GetFrame(height, width, xPos));
            button.SetTitle(title, UIControlState.Normal);
            button.SetTitleColor(new UIColor(1, 0, 0, 1), UIControlState.Normal);
            button.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Add(button);

            xPos += width;
            yPos += height;

            return button;
        }

        private CGRect GetFrame(int height, int width, int x)
        {
            var rect = new CGRect(x, yPos, width, height);
            return rect;
        }

        #endregion
    }
}