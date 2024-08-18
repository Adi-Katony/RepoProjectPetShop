using Microsoft.AspNetCore.Mvc;
using ProjectPetShop.Models;
using ProjectPetShop.Repositories;
using ProjectPetShop.Tests.FakeRepositories;

namespace ProjectPetShop.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public async Task IndexModelShouldBeListOfAnimals()
        {
            // Arrange
            var animalRepository = new FakeAnimalRepository();
            var homeController = new HomeController(animalRepository);

            // Act
            var result = await homeController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(List<Animal>));
        }
    }
}
