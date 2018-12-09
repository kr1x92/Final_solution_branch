using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Final_solution.Pages
{
    public class HeaderOfEtsyCom
    {
        public HeaderOfEtsyCom(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
