using OpenQA.Selenium;
using System.Collections.Generic;
using static Jupitor_Toys.Utilities.SeleniumUtilities;

namespace Jupitor_Toys.Pages
{
    public class CartPage : BasePage
    {
        public string Item1;
        public string Item2;
      //  public By ItemsList = By.XPath("//tr[@class='cart-item ng-scope']/td[1]");
        public By ItemsList = By.CssSelector("tr[class='cart-item ng-scope'] td:nth-child(1)");

        public void VerifyItems()
        {
            WaitForElements(driver, ItemsList);
            IList<IWebElement> CartItemList = FindElements(driver, ItemsList);
            Item1 = CartItemList[0].Text;
            Item2 = CartItemList[1].Text;
        }
    
    }
    
}