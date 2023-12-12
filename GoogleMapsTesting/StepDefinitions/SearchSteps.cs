using GoogleMapsTesting.Helpers;
using GoogleMapsTesting.Pages;
using GoogleMapsTesting.Pages.TransportTypePages;
using GoogleMapsTesting.Steps;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static GoogleMapsTesting.Models.TransportTypes;

namespace GoogleMapsTesting.StepDefinitions
{
    [Binding]
    public class SearchSteps : BaseSteps
    {
        public SearchSteps(IWebDriver driver, Logger logger) : base(driver, logger)
        {
        }

        [When(@"I search (.*), (.*) address")]
        public void WhenISearchNersisyanSt_YerevanAddress(string street, string city)
        {
            new SearchPage(_driver).SearchAddress(street, city);
        }

        [Then(@"(.*), (.*), (.*), (.*) address should be displayed")]
        public void ThenAddressShouldBeDisplayed(string buildingNumber, string street, string city, string postalCode)
        {
            var copyAddress = new SearchPage(_driver).GetCopyAddressText();
            Assert.IsTrue(copyAddress.Contains(buildingNumber) && copyAddress.Contains(street) && copyAddress.Contains(city) && copyAddress.
                Contains(postalCode), " Address is not displayed correctly");
        }

        [When(@"I search (.*) place")]
        public void WhenISearchAddress(string placeName)
        {
            new SearchPage(_driver).SearchAddress(placeName);
        }

        [Given(@"Directions is selected")]
        public void GivenDirectionsIsSelected()
        {
            new SearchPage(_driver).SelectDirections();
        }

        [When(@"I choose (.*) as starting point")]
        public void WhenIChooseStartingPoint(string startingPoint)
        {
            new SearchPage(_driver).ChooseStartingPoint(startingPoint);
        }

        [When(@"I choose (.*) as destination")]
        public void WhenIChooseDestination(string destination)
        {
            new SearchPage(_driver).ChooseDestination(destination);
        }

        [Then(@"Route information is displayed")]
        public void ThenRouteRouteInformationIsDisplayed()
        {
            new SearchPage(_driver).GetRouteInformation(out string routeInformationText);
            Assert.IsTrue(routeInformationText.Contains("hr") && (routeInformationText.Contains("miles") ||
                routeInformationText.Contains("km")), "Route information is not displayed");
        }

        [When(@"I add (.*) destinations")]
        public void WhenIAddDestinations(int numberOfDestinations)
        {
            for (int i = 0; i < numberOfDestinations; i++)
            {
                new SearchPage(_driver).AddRandomDestination();
            }
        }

        [Then(@"The (.*) route information will be displayed")]
        public void ThenTheFollowingTransportTypeInformationWillBeDisplayed(TransportType transportType)
        {
            switch (transportType)
            {
                case TransportType.Driving:
                    throw new PendingStepException();
                case TransportType.Cycling:
                    throw new PendingStepException();
                case TransportType.Flights:
                    throw new PendingStepException();
                case TransportType.Transit:
                    throw new PendingStepException();
                case TransportType.Walking:
                    WalkingPage walkingPg = new WalkingPage(_driver);
                    walkingPg.SelectTransportType();
                    walkingPg.GetRouteInformation(out string routeInfo);
                    Assert.Multiple(() =>
                    {
                        Assert.IsTrue(routeInfo.Contains("hr") && routeInfo.Contains("miles"), "Route info is not correctly displayed");
                        Assert.IsTrue(new WalkingPage(_driver).VerifyIconInformation(), "Icon information is not displayed");
                    });
                    break;
            }
        }

    }
}
