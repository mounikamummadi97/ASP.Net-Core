using Moq;
using System.Collections.Generic;
using xUnitTesting_WebAPI.Controllers;
using xUnitTesting_WebAPI.Interface;
using xUnitTesting_WebAPI.Model;

namespace TestProject1
{
    public class UnitTest1
    {
        
        [Fact]
        public void GetCustomerList_CustomerList()
        {
            //arrange
            var mockDataRepository = new Mock<IDataRepository>();
            mockDataRepository.Setup(x => x.GetCustomerList()).Returns(new List<Customer>
            { new Customer{CustomerId=1,CustomerName="mouni"},
              new Customer{CustomerId=2,CustomerName="vinny"} });
            var service = new CustomerController(mockDataRepository.Object);

            //act
            var result = service.CustomerList();
            //assert
            
            Assert.IsAssignableFrom<IEnumerable<Customer>>(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        //comment
        public void GetCustomerByID_Customer()
        {
            //unit test
            //arrange
            var mockDatarepository = new Mock<IDataRepository>();
            mockDatarepository.Setup(x => x.GetCustomerById(1)).Returns(new Customer { CustomerId = 1, CustomerName = "mouni" });
            
            var service = new CustomerController(mockDatarepository.Object);
            
            //act
            var Results = service.GetCustomerById(1);

            //assert
            Assert.IsType<Customer>(Results);
            Assert.Equal(1, Results.CustomerId);
            Assert.Equal("mouni", Results.CustomerName);
        }
        [Fact]
        public void AddCustomer_Inserts_Customer()
        {
            //Arrange
            var mockDataRepository = new Mock<IDataRepository>();
            var service = new CustomerController(mockDataRepository.Object);
            var customer = new Customer { CustomerId = 3, CustomerName = "sravan" };
            //Act
            service.AddCustomer(customer);
            //Assert
            mockDataRepository.Verify(x => x.Insert(customer), Times.Once);
        }
        [Fact]
        public void DeleteCustomer()
        {
            //arrange
            int id = 3;
            var mockRepository = new Mock<IDataRepository>();
            mockRepository.Setup(x => x.DeleteCustomer(id)).Returns(false);
            var service = new CustomerController(mockRepository.Object);
            //Act
            var result = service.DeleteCustomer(id);
            //Assert
            Assert.False(result);

        }
        public void UpdateCustomer()
        {
            //arrange 
            int id = 1;
            var customer = new Customer { CustomerId = 1, CustomerName = "mouni" };
            var mockRepository = new Mock<IDataRepository>();
            var service = new CustomerController(mockRepository.Object);
            //Act
            service.UpdateCustomer(id, customer);
            //Assert
            mockRepository.Verify(x=> x.UpdateCustomer(customer),Times.Once)
              

            
               
        }

    }
}




