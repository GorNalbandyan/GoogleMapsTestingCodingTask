using OpenQA.Selenium;

namespace GoogleMapsTesting.Pages
{
    internal class SearchPage : BasePage
    {
        private readonly By searchInput = By.Id("searchboxinput");
        private readonly By suggestion = By.XPath("//*[@aria-label = 'Suggestions']");
        private readonly By copyAddress = By.XPath("//*[@data-tooltip= 'Copy address']");
        private readonly By directions = By.XPath("//*[@aria-label = 'Directions']");
        private readonly By startingPointInput = By.XPath("//input[contains(@placeholder, 'starting point')]");
        private readonly By destinationInput = By.XPath("//input[contains(@placeholder, 'Choose destination')]");
        private readonly By routeInformation = By.Id("section-directions-trip-0");
        private readonly By addDestinationButton = By.XPath("//*[contains(text(), 'Add destination')]");

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

        public void SelectDirections()
        {
            Click(directions);
        }

        public void ChooseStartingPoint(string startingPoint)
        {
            Thread.Sleep(3000);
            EnterText(startingPointInput, startingPoint);
        }

        public void ChooseDestination(string destination)
        {
            EnterText(destinationInput, destination + Keys.Enter);
        }

        public void GetRouteInformation(out string routeInformationText)
        {
            routeInformationText = GetText(routeInformation);
        }

        public void AddRandomDestination()
        {
            WaitUntilVisible(routeInformation);
            Click(addDestinationButton);
            EnterText(destinationInput, Faker.Address.UsState() + Keys.Enter);
        
        }
    }
}
