using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using Training_QA_Automation.Framework.PageObjects;

namespace Training_QA_Automation.Framework.Tests
{
    [TestClass]
    public class RegistrationTest
    {
        private IWebDriver driver;
        private RegistrationPage registrationPage;
        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddAdditionalCapability(CapabilityType.Version, "latest", true);
            options.AddAdditionalCapability(CapabilityType.Platform, "Windows 10", true);
            options.AddAdditionalCapability("username", "rociofc0312", true);
            options.AddAdditionalCapability("accessKey", "0a956e06-8ff0-4924-bd14-6470679c6c13", true);
            options.AddAdditionalCapability("name", TestContext.TestName, true);

            this.driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(600));
            this.registrationPage = new RegistrationPage(driver);
        }

        [TestCleanup]
        public void CleanUp()
        {
            var passed = TestContext.CurrentTestOutcome == UnitTestOutcome.Passed;
            ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            driver?.Quit();
        }

        [TestMethod]
        public void RegistrationMethod()
        {
            registrationPage.GotToPage();
            registrationPage.ClickSignIn();
            registrationPage.ClickCreateAccount();
            Assert.AreEqual("Next", driver.FindElement(By.ClassName("btn-primary")).Text);
        }
    }
}
