using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Training_QA_Automation.Framework.PageObjects
{
    class AccountPage
    {
        public IWebDriver driver;

        public AccountPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "sign-out-mob")]
        private IWebElement SignOut;

        [FindsBy(How = How.Id, Using = "btn-info")]
        private IWebElement SignIn;

        [FindsBy(How = How.TagName, Using = "h1")]
        private IWebElement UsernameH1;

        public void ClickSignOut()
        {
            SignOut.ClickOn(driver);
        }

        public string GetUser()
        {
            return UsernameH1.Text.Split('\'')[0];
        }
    }
}
