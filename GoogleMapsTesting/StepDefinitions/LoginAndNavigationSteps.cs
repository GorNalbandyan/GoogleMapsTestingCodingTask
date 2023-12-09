using GoogleMapsTesting.Helpers;
using GoogleMapsTesting.Steps;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace GoogleMapsTesting.StepDefinitions
{
    [Binding]
    public class LoginAndNavigationSteps : BaseSteps
    {
        public LoginAndNavigationSteps(IWebDriver driver, Logger logger) : base(driver, logger)
        { 
        }

        [Given(@"Google Maps page is open")]
        public void GivenIAmOnGoogleMapsPage()
        {
            _driver.Navigate().GoToUrl(new SettingsHelper().Url);
            _logger.Info("Google Maps page is open");
        }
    }
}
