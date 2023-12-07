using OpenQA.Selenium;
using GoogleMapsTesting.Pages;

namespace GoogleMapsTesting.Pages
{
    internal class MainPage : BasePage
    {
        private readonly By searchBox = By.Id("searchbox");
        private readonly By signinBtn = By.Id("searchbox");

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public bool VerifyUIComponentIsDisplayed(string componentName)
        {
            return IsDisplayed(By.XPath($"//*[@aria-label = '{componentName}']"), 15);
        }

        public void HoverElement(string elementName)
        {
            WaitUntilVisible(By.XPath($"//*[@aria-label = '{elementName}']"));
            var selectorElement = _driver.FindElement(By.XPath($"//*[@aria-label = '{elementName}']"));
            HoverOverElement(selectorElement);
        }

        public bool VerifyMapTypeIsDisplayed(string mapType)
        {
            return IsDisplayed(By.XPath($"//button/label[contains(text(), '{mapType}')]"), 15);
        }

    }
}
