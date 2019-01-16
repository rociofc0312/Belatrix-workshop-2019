
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Linq;
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

        [FindsBy(How = How.ClassName, Using = "icon-plus")]
        private IWebElement AddInbox;

        [FindsBy(How = How.ClassName, Using = "user_name")]
        private IWebElement Username;

        [FindsBy(How = How.ClassName, Using = "success")]
        private IWebElement Accept;

        [FindsBy(How = How.ClassName, Using = "subject")]
        private IWebElement list1;

        public void OpenTabAndGoToPage(String queryParams = "")
        {
            Actions.OpenNewTab(driver);
            Actions.SwitchTab(driver, 1);
            driver.Navigate().GoToUrl("https://getnada.com/" + queryParams);
        }

        public void AddInboxTypeEmailAndAccept(string username)
        {
            AddInbox.ClickOn(driver);
            Username.Type(driver, username);
            Accept.ClickOn(driver);
        }

        public string GetRowCode()
        {
            string verificationCode;
            IWebElement row = Actions.WaitUntilElementExists(driver, By.ClassName("subject"));
            verificationCode = Regex.Match(row.Text, @"\d+").Value;
            Actions.SwitchTab(driver, 0);
            return verificationCode;
        }

        public void GoBack()
        {
            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

    }
}
