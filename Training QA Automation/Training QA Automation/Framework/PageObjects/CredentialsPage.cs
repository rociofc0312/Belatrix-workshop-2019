

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Training_QA_Automation.Framework.PageObjects
{
    class CredentialsPage
    {
        public IWebDriver driver;
        public CredentialsForm credentialsForm;

        public CredentialsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.credentialsForm = new CredentialsForm(this);
        }

        [FindsBy(How = How.Id, Using = "Username")]
        private IWebElement Username;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement Password;

        [FindsBy(How = How.Id, Using = "PhoneNumber")]
        private IWebElement PhoneNumber;

        [FindsBy(How = How.ClassName, Using = "btn-primary")]
        private IWebElement Next;

        public void ClickNext()
        {
            Next.ClickOn(driver);
        }

        public class CredentialsForm
        {
            private CredentialsPage credentialsPage;
            public CredentialsForm(CredentialsPage credentialsPage)
            {
                this.credentialsPage = credentialsPage;
            }

            public void TypeUsernamePasswordAndPhoneNumber(string username, string password, string phoneNumber)
            {
                credentialsPage.Username.Type(credentialsPage.driver, username);
                credentialsPage.Password.Type(credentialsPage.driver, password);
                credentialsPage.PhoneNumber.Type(credentialsPage.driver, phoneNumber);
            }

            public void FillFormAndClickNext(string username, string password, string phoneNumber = "")
            {
                TypeUsernamePasswordAndPhoneNumber(username, password, phoneNumber);
                credentialsPage.ClickNext();
            }
        }

    }
}
