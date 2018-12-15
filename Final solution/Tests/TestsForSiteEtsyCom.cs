using Final_solution.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Interactions;
using Final_solution.Utils;

namespace Final_solution.Tests
{
    public class TestsForSiteEtsyCom
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
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
            WebElementHelpers webElementHelperes = new WebElementHelpers();
            actions.MoveToElement(headerOfEtsyCom.ClothingAndShoes).Perform();
            webElementHelperes.WaitElement(driver, headerOfEtsyCom.ClothingAndShoesMens, 10);

            actions.MoveToElement(headerOfEtsyCom.ClothingAndShoesMens).Perform();
            headerOfEtsyCom.ClothingAndShoesMensBoots.Click();
            int freeShippingElements = webElementHelperes.CountOfElements(driver, By.XPath("//*[@class='text-body-smaller no-wrap']"));
            int freeShippingWithDiscountElements = webElementHelperes.CountOfElements(driver, By.XPath("//*[@class='text-body-smaller text-truncate']"));
            int freeShippingGeneralCount = freeShippingElements + freeShippingWithDiscountElements;

            Console.WriteLine(freeShippingGeneralCount);
        }

        [Test]
        public void FindItemsWithDiscountAndCheckThatOldPriceAndDiscountMarkedGreenColor()
        {
            string expectedColour = "rgba(46, 133, 57, 1)";
            HeaderOfEtsyCom headerOfEtsyCom = new HeaderOfEtsyCom(driver);
            Actions actions = new Actions(driver);
            WebElementHelpers webElementHelperes = new WebElementHelpers();
            actions.MoveToElement(headerOfEtsyCom.ClothingAndShoes).Perform();

            webElementHelperes.WaitElement(driver, headerOfEtsyCom.ClothingAndShoesMens, 10);
            actions.MoveToElement(headerOfEtsyCom.ClothingAndShoesMens).Perform();
            headerOfEtsyCom.ClothingAndShoesMensBoots.Click();
            var discounts = driver.FindElements(By.XPath("//*[@class='text-body-smaller promotion-price normal no-wrap ']"));
            foreach (var discount in discounts)
            {
                string actualColour = discount.GetCssValue("color");
                Assert.True(expectedColour == actualColour, $"Test failed, because {expectedColour} not equal {actualColour} for discounts elements");
            }
        }
    }
}
