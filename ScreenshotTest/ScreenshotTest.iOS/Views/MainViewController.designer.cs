// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ScreenshotTest.iOS.Views
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView ScreenshotImage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ShareScreenshotButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton TakeScreenshotButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ScreenshotImage != null) {
				ScreenshotImage.Dispose ();
				ScreenshotImage = null;
			}
			if (ShareScreenshotButton != null) {
				ShareScreenshotButton.Dispose ();
				ShareScreenshotButton = null;
			}
			if (TakeScreenshotButton != null) {
				TakeScreenshotButton.Dispose ();
				TakeScreenshotButton = null;
			}
		}
	}
}
