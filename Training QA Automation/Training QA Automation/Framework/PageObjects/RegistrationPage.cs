using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Training_QA_Automation.Framework.PageObjects
{
    public class RegistrationPage
    {
        private IWebDriver driver;
        Faker faker;

        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
            faker = new Faker("en");
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement Email;

        [FindsBy(How = How.Id, Using = "sign-in-desk")]
        private IWebElement SignIn;

        [FindsBy(How = How.ClassName, Using = "btn-default")]
        private IWebElement CreateAccount;

        [FindsBy(How = How.Id, Using = "SecurityCodeViewModel_Code1")]
        private IWebElement SecurityCode;

        [FindsBy(How = How.ClassName, Using = "btn-primary")]
        private IWebElement Verify;

        [FindsBy(How = How.Id, Using = "Username")]
        private IWebElement Username;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement Password;

        [FindsBy(How = How.Id, Using = "PhoneNumber")]
        private IWebElement PhoneNumber;

        [FindsBy(How = How.ClassName, Using = "btn-primary")]
        private IWebElement Next;

        [FindsBy(How = How.Id, Using = "secquestion1lg")]
        private IWebElement SecretQuestion1;

        [FindsBy(How = How.Id, Using = "SecretQuestion1_Answer")]
        public IWebElement SecretQuestion1Answer;

        [FindsBy(How = How.Id, Using = "secquestion2lg")]
        private IWebElement SecretQuestion2;

        [FindsBy(How = How.Id, Using = "SecretQuestion2_Answer")]
        public IWebElement SecretQuestion2Answer;

        [FindsBy(How = How.Id, Using = "secquestion3lg")]
        private IWebElement SecretQuestion3;

        [FindsBy(How = How.Id, Using = "SecretQuestion3_Answer")]
        public IWebElement SecretQuestion3Answer;

        [FindsBy(How = How.Id, Using = "btnAccept")]
        public IWebElement AcceptAndContinue;

        [FindsBy(How = How.ClassName, Using = "btn-link")]
        private IWebElement Skip;

        private IList<string> Questions
        {
            get { return new SelectElement(SecretQuestion1).Options.Where(x => !x.GetText().Contains("")).Select(x => x.GetText()).ToList(); }
        }

        public void GotToPage(String queryParams = "")
        {
            driver.Navigate().GoToUrl("https://aws-test.taxact.com" + queryParams);
        }

        public void OpenNew(String queryParams = "")
        {
            driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "t");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public void ClickSignIn()
        {
            SignIn.ClickOn(driver);
        }

        public void ClickCreateAccount()
        {
            CreateAccount.ClickOn(driver);
        }

        public string TypeEmail()
        {
            Email.Type(driver, faker.Person.UserName + "@mailinator.com");
            return faker.Person.UserName;
        }

        public void TypeVerificationCode(string code)
        {
            SecurityCode.Type(driver, code);
        }

        public void ClickVerify()
        {
            Verify.ClickOn(driver);
        }

        public void TypeUsername()
        {
            Username.Type(driver, faker.Person.UserName);
        }

        public void TypePassword()
        {
            Password.Type(driver, faker.Internet.Password());
        }

        public void TypePhoneNumber()
        {
            PhoneNumber.Type(driver, faker.Person.Phone);
        }

        public void ClickNext()
        {
            Next.ClickOn(driver);
        }

        public void FillSecretQuestion1()
        {
            new SelectElement(SecretQuestion1).SelectByText(faker.PickRandom(Questions));
            SecretQuestion1Answer.Type(driver, faker.Random.AlphaNumeric(12));
        }

        public void FillSecretQuestion2()
        {
            new SelectElement(SecretQuestion2).SelectByText(faker.PickRandom(Questions));
            SecretQuestion1Answer.Type(driver, faker.Random.AlphaNumeric(12));
        }

        public void FillSecretQuestion3()
        {
            new SelectElement(SecretQuestion3).SelectByText(faker.PickRandom(Questions));
            SecretQuestion1Answer.Type(driver, faker.Random.AlphaNumeric(12));
        }

        public void ClickAcceptAndContinue()
        {
            AcceptAndContinue.ClickOn(driver);
        }

        public void ClickSkip()
        {
            Skip.ClickOn(driver);
        }
    }
}
