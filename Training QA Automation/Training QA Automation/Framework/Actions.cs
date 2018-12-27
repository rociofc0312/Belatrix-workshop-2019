using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_QA_Automation.Framework
{
    class Actions
    {
        public void ClickOn(IWebDriver driver, IWebElement element)
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

        public void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public void WaitForPageToFinishLoading(IWebDriver driver, int timeout = 10)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeout);
        }
    }
}
