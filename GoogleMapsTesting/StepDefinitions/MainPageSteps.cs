using GoogleMapsTesting.Helpers;
using GoogleMapsTesting.Pages;
using GoogleMapsTesting.Steps;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GoogleMapsTesting.StepDefinitions
{
    [Binding]
    public class MainPageSteps : BaseSteps
    {
        public MainPageSteps(IWebDriver driver, Logger logger) : base(driver, logger)
        {
        }

        [Then(@"(.*) compontent should be displayed")]
        public void ThenTheFollowingUICompontentsShouldBeDisplayed(string componentName)
        {
            Assert.IsTrue(new MainPage(_driver).VerifyUIComponentIsDisplayed(componentName), $"{componentName} component is not displayed");
            _logger.Info($"{componentName} is successfully displayed");
        }

        [When(@"I hover over (.*)")]
        public void WhenIHoverOnInteractiveMap(string elementName)
        {
            new MainPage(_driver).HoverElement(elementName);
            _logger.Info($"Hovering on {elementName} element");
        }

        [Then(@"The following Map Details are displayed")]
        public void ThenTheFollowingDetailsAreDisplayed(Table mapDetailsTable)
        {
            var mapDetails = mapDetailsTable.CreateDynamicSet();
            Assert.Multiple(() =>
            {
                foreach (var map in mapDetails)
                {
                    Assert.IsTrue(new MainPage(_driver).VerifyMapTypeIsDisplayed(map.mapDetails), $"{map.mapDetails} component is not displayed");
                    _logger.Info($"Verifying {map.mapDetails} is successfully displayed");

                }
            });
        }
    }
}
