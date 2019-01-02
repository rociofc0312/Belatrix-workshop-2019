using OpenQA.Selenium;
using System;

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
    }
}
