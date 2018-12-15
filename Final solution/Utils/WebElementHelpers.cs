using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Final_solution.Utils
{
    public class WebElementHelpers
    {
        public void WaitElement(IWebDriver driver, IWebElement element, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
        }

        public int CountOfElements(IWebDriver driver, By by)
        {
            try
            {
                int count = driver.FindElements(by).Count;
                return count;
            }
            catch (Exception)
            {
                return -1000000000;
            }
        }

        public void EnteringTextToField(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public bool ElementIsPresent(IWebElement element, IWebDriver driver)
        {
            var present = false;
            try
            {
                present = element.Displayed;
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}