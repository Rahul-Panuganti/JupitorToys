using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jupitor_Toys.Pages;
using static Jupitor_Toys.Utilities.SeleniumUtilities;

namespace Jupitor_Toys.Tests.TestCases
{
    public class JupitorTestCases : TestBase
    {
        [Test]
        public void MandatoryErrorsDisplayedWhenFormIsNotFilled()
        {
            homePage = new HomePage();
            contactPage = homePage.NavigateToContactPage();

            /* Submit form without filling in mandatory fields*/
            contactPage.ClickSubmitButton();

            int count = contactPage.ErrorList();
            Assert.IsTrue(count > 0, $"Total error count must be greater than zero but it is {count}");

            Assert.AreEqual("Forename is required", GetTextFromWebElement(driver, contactPage.ForeNameError));
            Assert.AreEqual("Email is required", GetTextFromWebElement(driver, contactPage.EmailError));
            Assert.AreEqual("Message is required", GetTextFromWebElement(driver, contactPage.MessageRequiredError));

            /*Fill in all mandatory fields and submit form*/
            string firstName = "Rahul";
            string email = "Rahul@gmail.com";
            string message = "Rahul submitting form";
            contactPage.FillAllMandatoryFeilds(firstName, email, message);

            int newCount = contactPage.ErrorList();
            Assert.IsTrue(newCount == 0, $"Total error count must be zero but it is {newCount}");
        }

        [Test]
        public void SubmitFormSuccessfully()
        {
            homePage = new HomePage();
            contactPage = homePage.NavigateToContactPage();

            /*Fill in all mandatory fields and submit form*/
            string firstName = "Rahul";
            string email = "Rahul@gmail.com";
            string message = "Rahul submitting form";
            contactPage.FillAllMandatoryFeilds(firstName, email, message);
            contactPage.ClickSubmitButton();

            Assert.AreEqual($"Thanks {firstName}, we appreciate your feedback.", GetTextFromWebElement(driver, contactPage.SuccessMessage));
        }

        [Test]
        public void VerifyInvalidDataEntryForMandatoryFieldsDisplaysAnError()
        {
            homePage = new HomePage();
            contactPage = homePage.NavigateToContactPage();

            string invalidEmail1 = "Rahul";
            string invalidEmail2 = "Rahul@gmail";
            string invalidEmail3 = "asas1213@aaasa.comsa";
            string invalidEmail4 = "asg343@.com";

            /* First name and message take in all values, hence invalid data entry validation is not possible */
            contactPage.FillAllEmailField(invalidEmail1);
            Assert.AreEqual("Please enter a valid email", GetTextFromWebElement(driver, contactPage.EmailError));

            contactPage.FillAllEmailField(invalidEmail2);
            Assert.AreEqual("Please enter a valid email", GetTextFromWebElement(driver, contactPage.EmailError));

            contactPage.FillAllEmailField(invalidEmail3);
            Assert.AreEqual("Please enter a valid email", GetTextFromWebElement(driver, contactPage.EmailError));

            contactPage.FillAllEmailField(invalidEmail4);
            Assert.AreEqual("Please enter a valid email", GetTextFromWebElement(driver, contactPage.EmailError));
        }

        [Test]
        public void AddVariousItemsToCartAndVerifyItemsAddedSuccessfully()
        {
            homePage = new HomePage();
            shoppingPage = homePage.NavigateToShoppingPage();

            shoppingPage.AddItemToCart(shoppingPage.FunnyCow);
            shoppingPage.AddItemToCart(shoppingPage.FunnyCow);
            shoppingPage.AddItemToCart(shoppingPage.FluffyBunny);
            
            /*Clicking the cart menu and verifying items*/
            cartPage = shoppingPage.ClickOnCart();
            cartPage.VerifyItems();
            Assert.AreEqual("Funny Cow", cartPage.Item1);
            Assert.AreEqual("Fluffy Bunny", cartPage.Item2);

        }
    }
}

