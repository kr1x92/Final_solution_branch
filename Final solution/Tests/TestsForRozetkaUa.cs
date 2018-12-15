using Final_solution.Pages;
using Final_solution.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;

namespace Final_solution.Tests
{
    public class TestsForRozetkaUa
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://rozetka.com.ua/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void NavigateToAsusCategoryInLaptopsSection()
        {
            string expectedText = "Ноутбуки Asus";
            RozetkaPage rozetkaPage = new RozetkaPage(driver);
            Actions actions = new Actions(driver);
            WebElementHelpers webElementHelpers = new WebElementHelpers();
            webElementHelpers.WaitElement(driver, rozetkaPage.LaptopsAndComputers, 10);

            actions.MoveToElement(rozetkaPage.LaptopsAndComputers).Perform();
            webElementHelpers.WaitElement(driver, rozetkaPage.AsusFromLaptopsSection, 10);
            rozetkaPage.AsusFromLaptopsSection.Click();
            string actualText = driver.FindElement(By.CssSelector("h1")).GetAttribute("innerText");
            Assert.True(expectedText == actualText, $"Test Failed, because {expectedText} doesn't equal {actualText}. Please check.");
        }
    }
}
