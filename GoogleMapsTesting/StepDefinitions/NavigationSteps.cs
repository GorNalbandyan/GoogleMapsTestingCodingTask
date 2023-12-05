using GoogleMapsTesting.Helpers;
using GoogleMapsTesting.Steps;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace GoogleMapsTesting.StepDefinitions
{
    [Binding]
    public class NavigationSteps : BaseSteps
    {
        public NavigationSteps(IWebDriver driver, Logger logger) : base(driver, logger)
        { 
        }

        [Given(@"I am on Google Maps page")]
        public void GivenIAmOnGoogleMapsPage()
        {
            _driver.Navigate().GoToUrl(new SettingsHelper().Url);
        }
    }
}
