using Jupitor_Toys.Tests;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Jupitor_Toys.Utilities.SeleniumUtilities;

namespace Jupitor_Toys.Pages
{
    public class ShoppingPage : BasePage
    {
        public By FunnyCow = By.CssSelector("li[id='product-6'] a");
        public By FluffyBunny = By.CssSelector("li[id='product-4'] a");
        public By CartItems = By.CssSelector("li[id='nav-cart'] span");

        public void AddItemToCart(By by)
        {
            WaitForElement(driver, by);
            FindElement(driver, by).Click();
        }

        public CartPage ClickOnCart()
        {
            WaitForElement(driver, CartItems);
            FindElement(driver, CartItems).Click();
            return new CartPage();
        }
    }
}
