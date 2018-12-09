using Final_solution.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace Final_solution.Tests
{
    public class TestsForSiteEtsyCom
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://www.etsy.com");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void CountOfElementsWithFreeShipping()
        {
            HeaderOfEtsyCom headerOfEtsyCom = new HeaderOfEtsyCom(driver);
            Actions actions = new Actions(driver);
            actions.MoveToElement(headerOfEtsyCom.ClothingAndShoes).Build().Perform();
            actions.MoveToElement(headerOfEtsyCom.ClothingAndShoesMens).Build().Perform();
            headerOfEtsyCom.ClothingAndShoesMensBoots.Click();
            Thread.Sleep(TimeSpan.FromSeconds(150));
        }

        //[Test]
        //public void FindItemsWithDiscountAndCheckThatOldPriceAndDiscountMarkedGreenColor()
        //{
        //    Console.WriteLine("OK");
        //}
    }
}
