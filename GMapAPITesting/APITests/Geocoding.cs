using Google.Maps;
using NUnit.Framework;
using Google.Maps.Geocoding;

namespace GMapAPITesting.APITests
{
    internal class Geocoding : GoogleSignUpTextFixture
    {
        GeocodingRequest request;

        [SetUp]
        public void InitializeGeocoding()
        {
            request = new GeocodingRequest();
        }

        [TestCase("1600 Pennsylvania Ave NW, Washington, DC 20500", "1600 Pennsylvania Ave NW, Washington, DC 20500, USA")]
        [TestCase("1600 Pennsylvania Washington", "1600 Pennsylvania Ave NW, Washington, DC 20500, USA")]
        public void GetFormattedAddress(string address, string expectedFormattedAddress)
        {
            request.Address = address;
            var response = new GeocodingService().GetResponse(request);
            Assert.AreEqual(ServiceResponseStatus.Ok, response.Status, $"Response status was not successfull, it was: {response.Status} -- {response.ErrorMessage}");
            Assert.AreEqual(expectedFormattedAddress, response.Results.FirstOrDefault().FormattedAddress, "Formatted address is not correct");

        }
    }
}
