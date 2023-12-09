using Google.Maps;
using NUnit.Framework;
using GoogleMapsTesting.Helpers;

namespace GMapAPITesting
{
    [Parallelizable(ParallelScope.All), TestFixture]
    public class GoogleSignUpTextFixture
    {
        [SetUp]
        public void GoogleSignedSetUp()
        {
            try
            {
                var myAPIKey = new SettingsHelper().GoogleAPIKey;
                GoogleSigned.AssignAllServices(new GoogleSigned(myAPIKey));
            }
            catch(Exception ex)
            {
                Assert.Fail($"Couldn't set up Google Signed beacuse of the error: {ex.Message}");
            }
            
        }
    }
}