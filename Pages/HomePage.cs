using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Jupitor_Toys.Utilities.SeleniumUtilities;

namespace Jupitor_Toys.Pages
{
    public class HomePage : BasePage
    {
        //public IWebDriver driver;

        By ContactPageLink = By.CssSelector("a[href='#/contact']");

        By ShopPageLink = By.LinkText("Shop");

        public ContactPage NavigateToContactPage()
        {
            WaitForElement(driver, ContactPageLink);
            FindElement(driver, ContactPageLink).Click();
            return new ContactPage();
        }

        public ShoppingPage NavigateToShoppingPage()
        {
            WaitForElement(driver, ShopPageLink);
            FindElement(driver, ShopPageLink).Click();
            return new ShoppingPage();
        }
    }
}
