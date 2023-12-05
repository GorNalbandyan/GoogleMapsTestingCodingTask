using GoogleMapsTesting.Helpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace GoogleMapsTesting.Steps
{
    [Binding]
    public class BaseSteps 
    {
        public readonly IWebDriver _driver;
        public readonly Logger _logger;

        public BaseSteps(IWebDriver driver, Logger logger)
        {
            _driver = driver;
            _logger = logger;
        }

    }
}