using GoogleMapsTesting.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsTesting.Pages.TransportTypePages
{
    public class WalkingPage : BasePage, ITransportType
    {

        private readonly By walkingModebutton = By.XPath("//*[@aria-label = 'Walking']");
        private readonly By iconDetails = By.XPath("//*[@data-travel_mode = '2']");
        private readonly By routeInformation = By.Id("section-directions-trip-0");

        public WalkingPage(IWebDriver driver) : base(driver)
        {
        }

        public void SelectTransportType() 
        {
            Click(walkingModebutton);
        }

        public bool VerifyIconInformation()
        {
            var timeUnderIcon = GetText(iconDetails);
            return timeUnderIcon.Contains("days") || timeUnderIcon.Contains("hr");

        }

        public void GetRouteInformation(out string routeInfo)
        {
            WaitUntilVisible(routeInformation);
            routeInfo = GetText(routeInformation);
        }

    }
}
