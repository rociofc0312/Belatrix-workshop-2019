using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Training_QA_Automation.Framework
{
    static class Actions
    {
        public static void ClickOn(this IWebElement element, IWebDriver driver)
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

        public static void Type(this IWebElement element, IWebDriver driver, string text)
        {
            element.ClickOn(driver);
            element.Clear();
            element.SendKeys(text);
        }

        public static void WaitForPageToFinishLoading(IWebDriver driver, int timeout = 10)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeout);
        }

        public static IWebElement WaitUntilElementExists(IWebDriver driver, By elementLocator, int timeout = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

            return wait.Until(ExpectedConditions.ElementExists(elementLocator));
        }

        public static string GetText(this IWebElement e)
        {
            string webElementText = e.Text;
            if (String.IsNullOrEmpty(webElementText))
            {
                string webElementTextAttribute = e.GetAttribute("value");
                if (!String.IsNullOrEmpty(webElementTextAttribute)) return webElementTextAttribute;
            }
            return webElementText;
        }

        public static void OpenNewTab(IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
        }

        public static void SwitchTab(IWebDriver driver, int index)
        {
            List<String> tabs = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs.ElementAt(index));
        }
    }
}
