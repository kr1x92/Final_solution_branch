using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Final_solution.Pages
{
    public class RozetkaPage
    {
        public RozetkaPage (IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@href='https://rozetka.com.ua/computers-notebooks/c80253/']")]
        public IWebElement LaptopsAndComputers;

        [FindsBy(How = How.XPath, Using = "//*[@href='https://rozetka.com.ua/notebooks/asus/c80004/v004/']")]
        public IWebElement AsusFromLaptopsSection;
    }
}
