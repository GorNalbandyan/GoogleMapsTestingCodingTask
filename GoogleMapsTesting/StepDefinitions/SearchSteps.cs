using GoogleMapsTesting.Helpers;
using GoogleMapsTesting.Pages;
using GoogleMapsTesting.Steps;
using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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
            Assert.IsTrue(copyAddress.Contains(buildingNumber)&& copyAddress.Contains(street) && copyAddress.Contains(city) && copyAddress.
                Contains(postalCode), " Address is not displayed correctly");
        }

        [When(@"I search (.*) place")]
        public void WhenISearchAddress(string placeName)
        {
            new SearchPage(_driver).SearchAddress(placeName);



        }
    }
}
