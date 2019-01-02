
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Text.RegularExpressions;

namespace Training_QA_Automation.Framework.PageObjects
{
    class EmailInboxPage
    {
        private IWebDriver driver;

        public EmailInboxPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "inboxfield")]
        private IWebElement Inbox;

        [FindsBy(How = How.ClassName, Using = "btn-dark")]
        private IWebElement Go;

        [FindsBy(How = How.TagName, Using = "table")]
        private IWebElement table;

        public void GotToPage(String queryParams = "")
        {
            driver.Navigate().GoToUrl("https://www.mailinator.com/" + queryParams);
        }

        public void TypeEmail(string email)
        {
            Inbox.Type(driver, email);
        }

        public void ClickGo()
        {
            Go.ClickOn(driver);
        }

        public string GetRowCode()
        {
            string verificationCode;
            IWebElement row = table.FindElement(By.XPath("//tr/td[contains(text(), 'Your Account Verification Code Is 542186')]"));
            verificationCode = Regex.Match(row.Text, @"\d+").Value;
            return verificationCode;
        }

    }
}
