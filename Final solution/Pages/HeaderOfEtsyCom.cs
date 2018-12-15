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

        [FindsBy(How = How.XPath, Using = "//*/li[2]/a[@href='/c/clothing-and-shoes?ref=catnav-10923']")]
        public IWebElement ClothingAndShoes;

        [FindsBy(How = How.XPath, Using = "//*[@id='side-nav-category-link-10936']")]
        public IWebElement ClothingAndShoesMens;

        [FindsBy(How = How.XPath, Using = "//*[@id='catnav-l4-11109']")]
        public IWebElement ClothingAndShoesMensBoots;
    }
}
