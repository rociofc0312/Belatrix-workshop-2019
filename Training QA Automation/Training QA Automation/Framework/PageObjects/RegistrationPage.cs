using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [FindsBy(How = How.Name, Using = "Email")]
        private IWebElement email;

        [FindsBy(How = How.Id, Using = "sign-in-desk")]
        private IWebElement SignIn;

        [FindsBy(How = How.CssSelector, Using = "#header > div > div > div.col-xs-8.text-right > div > a")]
        private IWebElement CreateAccount;
        
        public void GotToPage(String queryParams = "")
        {
            driver.Navigate().GoToUrl("https://aws-test.taxact.com" + queryParams);
        }
    }
}
