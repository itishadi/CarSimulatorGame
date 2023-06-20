using GameLibrary.APIModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameLibrary.Tests.APIModels
{
    [TestClass]
    public class ApiResponseTests
    {
        [TestMethod]
        public void ApiResponse_ReturnsNonNullNameAndAge_WhenSet()
        {
            // Arrange
            var apiResponse = new ApiResponse();
            var result = new Result();
            result.name = new Name { first = "John", last = "Doe" };
            result.dob = new Dob { age = 30 };
            apiResponse.results = new[] { result };

            // Act
            var name = apiResponse.results[0].name;
            var age = apiResponse.results[0].dob.age;

            // Assert
            Assert.IsNotNull(name);
            Assert.IsNotNull(name.first);
            Assert.IsNotNull(name.last);
            Assert.IsFalse(string.IsNullOrEmpty(name.first));
            Assert.IsFalse(string.IsNullOrEmpty(name.last));
            Assert.IsTrue(age > 0);
        }
    }
}
