using System;

namespace Plugin.Screenshot.Abstractions
{
  /// <summary>
  /// Interface for Screenshot
  /// </summary>
  public interface IScreenshot
  {
      bool TakeScreenshot(string screenshotPath, object screen);
  }
}
