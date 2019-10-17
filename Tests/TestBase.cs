using Jupitor_Toys.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using static Jupitor_Toys.Utilities.SeleniumUtilities;

namespace Jupitor_Toys.Tests
{
    public class TestBase
    {
        public static IWebDriver driver;
        public HomePage homePage;
        public ContactPage contactPage;
        public ShoppingPage shoppingPage;
        public CartPage cartPage;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            String ApplicationUrl = ConfigurationManager.AppSettings["url"];
            driver.Url = ApplicationUrl;

            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [TearDown]
        public void TearDown()
        {
            TakeScreenShotOnFailure();
            driver.Quit();
        }
    }
}
