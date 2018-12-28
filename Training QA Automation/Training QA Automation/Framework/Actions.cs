using OpenQA.Selenium;
using System;

namespace Training_QA_Automation.Framework
{
    static class Actions
    {
        public static void ClickOn(IWebDriver driver, IWebElement element)
        {
            WaitForPageToFinishLoading(driver);
            try
            {
                element.Click();
                WaitForPageToFinishLoading(driver);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public static void Type(IWebDriver driver, IWebElement element, string text)
        {
            ClickOn(driver, element);
            element.Clear();
            element.SendKeys(text);
        }

        public static void WaitForPageToFinishLoading(IWebDriver driver, int timeout = 10)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeout);
        }
    }
}
