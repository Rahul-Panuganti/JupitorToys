using Jupitor_Toys.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using Jupitor_Toys.Tests;
using System.IO;

namespace Jupitor_Toys.Utilities
{
    public class SeleniumUtilities : TestBase
    {
        public static IWebElement FindElement(IWebDriver driver, By by)
        {
            return driver.FindElement(by);
        }

        public static IList<IWebElement> FindElements(IWebDriver driver, By by)
        {
            return driver.FindElements(by);
        }

        public static void WaitForElement(IWebDriver driver, By by)
        {
            WebDriverWait Wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
        }

        public static void WaitForElements(IWebDriver driver, By by)
        {
            WebDriverWait Wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }

        public static string GetTextFromWebElement(IWebDriver driver, By by)
        {
            WaitForElement(driver, by);
            return FindElement(driver, by).Text;
        }

        public static void TakeScreenShotOnFailure()
        {
            var currentContext = NUnit.Framework.TestContext.CurrentContext;

            if (currentContext.Result.Outcome != NUnit.Framework.Interfaces.ResultState.Success)
            {
                var testName = currentContext.Test.Name;
                String filename = @"C:\Screenshots\" + testName + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".Png";

                // Take screenshot
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                // Create directory if doesn't exist
                Directory.CreateDirectory(Path.GetDirectoryName(filename));

                // Save file            
                ss.SaveAsFile(filename, OpenQA.Selenium.ScreenshotImageFormat.Png);

            }
        }

    }
}
