using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Training_QA_Automation.Framework.PageObjects;

namespace Training_QA_Automation.Framework.Tests
{
    [TestClass]
    public class RegistrationTest
    {
        private IWebDriver driver;
        Faker faker;
        private RegistrationPage registrationPage;
        private EmailInboxPage emailInboxPage;
        private CredentialsPage credentialsPage;
        private SecretQuestionsPage questionsPage;
        private AccountPage accountPage;
        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void SetUp()
        {
            /*var sauceUserName = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
            var sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);
            ChromeOptions options = new ChromeOptions();
            options.AddAdditionalCapability(CapabilityType.Version, "latest", true);
            options.AddAdditionalCapability(CapabilityType.Platform, "Windows 10", true);
            options.AddAdditionalCapability("username", sauceUserName, true);
            options.AddAdditionalCapability("accessKey", sauceAccessKey, true);
            options.AddAdditionalCapability("name", TestContext.TestName, true);

            this.driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(600));*/
            this.driver = new ChromeDriver();
            faker = new Faker("en");
        }

        [TestCleanup]
        public void CleanUp()
        {
            /*var passed = TestContext.CurrentTestOutcome == UnitTestOutcome.Passed;
            ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));*/
            driver?.Quit();
        }

        [TestMethod]
        public void RegistrationMethod()
        {
            string username = faker.Person.UserName;
            string email = username + "@getnada.com";
            string password = "TestTest01!";
            string verificationCode;

            registrationPage = new RegistrationPage(driver);
            emailInboxPage = new EmailInboxPage(driver);
            credentialsPage = new CredentialsPage(driver);
            questionsPage = new SecretQuestionsPage(driver);
            accountPage = new AccountPage(driver);

            registrationPage.GoToPage();
            registrationPage.registrationForm.TypeEmailAndClickNext(email);
            emailInboxPage.OpenTabAndGoToPage();
            emailInboxPage.AddInboxTypeEmailAndAccept(username);
            verificationCode = emailInboxPage.GetRowCode();
            registrationPage.TypeVerificationCodeAndClickVerify(verificationCode);
            credentialsPage.credentialsForm.FillFormAndClickNext(username, password);
            questionsPage.secretQuestionsForm.PopulateQAFormAndClickNext();
            registrationPage.ClickAcceptAndContinue();
            registrationPage.ClickSkip();
            Assert.AreEqual(username.ToLower(), accountPage.GetUser());
        }

        [TestMethod]
        public void RegistrationMethodWithEmailAlreadyExist()
        {
            string username = faker.Person.UserName;
            string email = username + "@getnada.com";
            string password = "TestTest01!";
            string verificationCode;

            registrationPage = new RegistrationPage(driver);
            emailInboxPage = new EmailInboxPage(driver);
            credentialsPage = new CredentialsPage(driver);
            questionsPage = new SecretQuestionsPage(driver);
            accountPage = new AccountPage(driver);

            registrationPage.GoToPage();
            registrationPage.registrationForm.TypeEmailAndClickNext(email);
            emailInboxPage.OpenTabAndGoToPage();
            emailInboxPage.AddInboxTypeEmailAndAccept(username);
            verificationCode = emailInboxPage.GetRowCode();
            registrationPage.TypeVerificationCodeAndClickVerify(verificationCode);
            credentialsPage.credentialsForm.FillFormAndClickNext(username, password);
            questionsPage.secretQuestionsForm.PopulateQAFormAndClickNext();
            registrationPage.ClickAcceptAndContinue();
            registrationPage.ClickSkip();
            Assert.AreEqual(username.ToLower(), accountPage.GetUser());
            accountPage.ClickSignOut();
            registrationPage.GoToPage();
            registrationPage.registrationForm.TypeEmailAndClickNext(email);

            Assert.AreEqual("Email already in use", registrationPage.GetAlreadyExistMessage());
        }
    }
}
