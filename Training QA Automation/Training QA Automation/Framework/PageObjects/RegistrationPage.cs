using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Linq;

namespace Training_QA_Automation.Framework.PageObjects
{
    public class RegistrationPage
    {
        public RegistrationForm registrationForm;
        private IWebDriver driver;
        Faker faker;

        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
            //faker = new Faker("en");
            PageFactory.InitElements(driver, this);
            registrationForm = new RegistrationForm(this);
        }

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement Email;

        [FindsBy(How = How.ClassName, Using = "btn-primary")]
        private IWebElement Next;

        [FindsBy(How = How.Id, Using = "sign-in-desk")]
        private IWebElement SignIn;

        [FindsBy(How = How.ClassName, Using = "btn-default")]
        private IWebElement CreateAccount;

        [FindsBy(How = How.Id, Using = "SecurityCodeViewModel_Code1")]
        private IWebElement SecurityCode;

        [FindsBy(How = How.ClassName, Using = "btn-primary")]
        private IWebElement Verify;

        [FindsBy(How = How.Id, Using = "btnAccept")]
        public IWebElement AcceptAndContinue;

        [FindsBy(How = How.ClassName, Using = "btn-link")]
        private IWebElement Skip;

        [FindsBy(How = How.TagName, Using = "h4")]
        private IWebElement AlreadyExist;

        public void GoToPage(String queryParams = "")
        {
            driver.Navigate().GoToUrl("https://aws-test.taxact.com/auth/create-account" + queryParams);
        }

        public void ClickNext()
        {
            Next.ClickOn(driver);
        }

        public void TypeVerificationCodeAndClickVerify(string code)
        {
            SecurityCode.Type(driver, code);
            Verify.ClickOn(driver);
        }

        public void ClickAcceptAndContinue()
        {
            AcceptAndContinue.ClickOn(driver);
        }

        public void ClickSkip()
        {
            Skip.ClickOn(driver);
        }

        public string GetAlreadyExistMessage()
        {
            return AlreadyExist.Text;
        }

        public class RegistrationForm
        {
            private RegistrationPage registrationPage;

            public RegistrationForm(RegistrationPage registrationPage)
            {
                this.registrationPage = registrationPage;
            }

            private void TypeEmail(string email)
            {
                registrationPage.Email.Type(registrationPage.driver, email);
            }

            public void TypeEmailAndClickNext(string email)
            {
                TypeEmail(email);
                registrationPage.ClickNext();
            }
        }
    }
}
