using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Jupitor_Toys.Utilities.SeleniumUtilities;

namespace Jupitor_Toys.Pages
{
    public class ContactPage : BasePage
    {
        By SubmitButton = By.CssSelector("a[class='btn-contact btn btn-primary']");
        By Errors = By.CssSelector("span[class='help-inline ng-scope']");
        By FirstName = By.Id("forename");
        By Email = By.Id("email");
        By Message = By.Id("message");
        public By SuccessMessage = By.CssSelector("div[class='alert alert-success']");
        public By ForeNameError = By.Id("forename-err");
        public By EmailError = By.Id("email-err");
        public By MessageRequiredError = By.Id("message-err");

        public void ClickSubmitButton()
        {
            WaitForElement(driver, SubmitButton);
            FindElement(driver, SubmitButton).Click();
        }

        public int ErrorList()
        {
            IList<IWebElement> ErrList = FindElements(driver, Errors);
            return ErrList.Count();
        }

        public void FillAllMandatoryFeilds(String forename, String email, String message)
        {
            FindElement(driver, FirstName).SendKeys(forename);
            FindElement(driver, Email).SendKeys(email);
            FindElement(driver, Message).SendKeys(message);            
        }

        public void FillAllEmailField(String email)
        {
            FindElement(driver, Email).Clear();
            FindElement(driver, Email).SendKeys(email);
        }

        public Boolean SuccessSubmitionMessage()
        {
            return FindElement(driver, SuccessMessage).Displayed;
        }
    }
}
