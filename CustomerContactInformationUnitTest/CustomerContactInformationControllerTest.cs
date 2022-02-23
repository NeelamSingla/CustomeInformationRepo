using CustomerContactInformationService.Controllers;
using CustomerContactInformationService.Models;
using CustomerContactInformationService.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CustomerContactInformationUnitTest
{
    [TestClass]
    public class CustomerContactInformationControllerTest
    {
        private CustomerInformationController customerInformationController;
        private Mock<ICustomerInformationService> mockService;

        [TestInitialize]
        public void Init()
        {
            mockService = new Mock<ICustomerInformationService>();
            customerInformationController = new CustomerInformationController(mockService.Object);
        }

        [TestMethod]
        public void GetCustomerBySsnReturnOk()
        {
            // Arrange
            var testCustomer = new CustomerContactInformation()
                { 
                SocialSecurityNumber = "1233444444",
                EmailAddress = "test123@gmail.com",
                PhoneNumber = "44444444"
            };
            mockService.Setup(s => s.GetCustomersList()).Returns(new System.Collections.Generic.List<CustomerContactInformation>() { testCustomer });
            // Act
            mockService = new Mock<ICustomerInformationService>();
            var okResult = customerInformationController.GetAllCustomers();

            if(okResult is OkObjectResult data)
            {
                var customerList = (List<CustomerContactInformation>)data.Value;
                // Assert
                Assert.IsTrue(customerList.FirstOrDefault().SocialSecurityNumber == "1233444444");
            }   
            
        }
    }
}
