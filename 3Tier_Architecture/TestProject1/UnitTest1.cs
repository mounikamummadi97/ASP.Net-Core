using _3Tier_Architecture.Controllers;
using Castle.Core.Logging;
using Employee_DBLayer.Model;
using Interface.DataRepository;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using MySqlX.XDevAPI.Common;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetAllEmployees_Returns_404_IfClassIdNotFound()
        {
            // Arrange
            var mockRepo = new Mock<IDataRepository<Employee>>();

            mockRepo.Setup(X => X.GetAllEmployees())
                            .Returns(new List<Employee> { new Employee { EmployeeId = 1, EmployeeName = "John" }, new Employee { EmployeeId = 2, EmployeeName = "Jane" } });
            var controller = new EmployeeController(mockRepo.Object);
            //Act
            var result = CreateObjectUnderTest().GetAllEmployees(400, EmployeeDataManager.Object);
            //var result = await controller.GetAllEmployees();

            //Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IStatusCodeActionResult>(result);
            Assert.Equal(404, (result as IStatusCodeActionResult).StatusCode);
        }

        private EmployeeController CreateObjectUnderTest() =>

        new EmployeeController(
                iDataRepository: _iDataRepository.Object
                   );
        private readonly Mock<IDataRepository<EmployeeController>> _iDataRepository = new Mock<IDataRepository<EmployeeController>>();

    }
}