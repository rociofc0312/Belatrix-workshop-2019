using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Training_QA_Automation.Framework.PageObjects
{
    public class RegistrationPage
    {
        private IWebDriver driver;
        
        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement Email;

        [FindsBy(How = How.Id, Using = "sign-in-desk")]
        private IWebElement SignIn;

        [FindsBy(How = How.ClassName, Using = "btn-default")]
        private IWebElement CreateAccount;
        
        public void GotToPage(String queryParams = "")
        {
            driver.Navigate().GoToUrl("https://aws-test.taxact.com" + queryParams);
        }

        public void ClickSignIn()
        {
            Actions.ClickOn(driver, SignIn);
        }

        public void ClickCreateAccount()
        {
            Actions.ClickOn(driver, CreateAccount);
        }
    }
}
