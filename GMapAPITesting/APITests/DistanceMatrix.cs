using Google.Maps;
using Google.Maps.DistanceMatrix;
using GoogleMapsTesting.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Maps.DistanceMatrix.DistanceMatrixResponse;

namespace GMapAPITesting.APITests
{
    internal class DistanceMatrix : GoogleSignUpTextFixture
    {
        DistanceMatrixRequest request;

        [SetUp]
        public void InitializeDistanceMatrix()
        {
            request = new DistanceMatrixRequest();
        }

        [TestCase("Yerevan", "Berlin", "3826")]
        public void GetDistance(string originAddress, string destinationAddress, int expectedDistance)
        {
            request.AddOrigin(originAddress);
            request.AddDestination(destinationAddress);
            request.TransitMode = TransitModes.bus;
            var response = new DistanceMatrixService().GetResponse(request);
            Assert.AreEqual(ServiceResponseStatus.Ok, response.Status, $"Response status was not successfull, it was: {response.Status}");
            Assert.AreEqual(expectedDistance, new DistanceMatrixElement().distance, "Distance is not correct.");

        }
    }
}
