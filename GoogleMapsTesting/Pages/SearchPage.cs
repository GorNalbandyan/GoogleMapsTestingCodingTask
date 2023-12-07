using OpenQA.Selenium;

namespace GoogleMapsTesting.Pages
{
    internal class SearchPage : BasePage
    {
        private readonly By searchInput = By.Id("searchboxinput");
        private readonly By suggestion = By.XPath("//*[@aria-label = 'Suggestions']");
        private readonly By copyAddress = By.XPath("//*[@data-tooltip= 'Copy address']");

        public SearchPage(IWebDriver driver) : base(driver)
        {

        }

        public void SearchAddress(string street, string city)
        {
            EnterText(searchInput, street + " " + city);
            WaitUntilVisible(suggestion);
            _driver.FindElements(suggestion).First().Click();
        }

        public void SearchAddress(string placeName)
        {
            EnterText(searchInput, placeName + Keys.Enter);
        }

        public string GetCopyAddressText()
        {
            return GetText(copyAddress);
        }
    }
}
