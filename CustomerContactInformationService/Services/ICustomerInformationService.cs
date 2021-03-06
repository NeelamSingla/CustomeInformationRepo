using CustomerContactInformationService.Models;
using CustomerContactInformationService.ViewModels;
using System.Collections.Generic;

namespace CustomerContactInformationService.Services
{
    public interface ICustomerInformationService
    {
        /// <summary>
        /// get list of all customers
        /// </summary>
        /// <returns></returns>
        List<CustomerContactInformation> GetCustomersList();

        /// <summary>
        /// get customer details by customer id
        /// </summary>
        /// <param name="ssn"></param>
        /// <returns></returns>
        CustomerContactInformation GetCustomerDetailsBySSN(string ssn);

        /// <summary>
        ///  add edit customers
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns></returns>
        ResponseModel SaveCustomer(CustomerContactInformation CustomerModel);


        /// <summary>
        /// delete customers
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        ResponseModel DeleteCustomer(string ssn);
    }
}
