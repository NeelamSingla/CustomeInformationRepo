using System;
using System.Collections.Generic;
using System.Linq;
using CustomerContactInformationService.Models;
using CustomerContactInformationService.ViewModels;

namespace CustomerContactInformationService.Services
{
    public class CustomerInformationService : ICustomerInformationService
    {
        private CustomerContext _context;
        public CustomerInformationService(CustomerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// get list of all employees
        /// </summary>
        /// <returns></returns>
        public List<CustomerContactInformation> GetCustomersList()
        {
            List<CustomerContactInformation> empList;
            try
            {
                empList = _context.Set<CustomerContactInformation>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return empList;
        }


        /// <summary>
        /// get customer details by customer id
        /// </summary>
        /// <param name="ssn"></param>
        /// <returns></returns>
        public CustomerContactInformation GetCustomerDetailsBySSN(string ssn)
        {
            CustomerContactInformation emp;
            try
            {
                emp = _context.Find<CustomerContactInformation>(ssn);
            }
            catch (Exception)
            {
                throw;
            }
            return emp;
        }


        /// <summary>
        ///  add edit employee
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns></returns>
        public ResponseModel SaveCustomer(CustomerContactInformation customerModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                CustomerContactInformation _temp = GetCustomerDetailsBySSN(customerModel.SocialSecurityNumber);
                if (_temp != null)
                {
                     _temp.SocialSecurityNumber = customerModel.SocialSecurityNumber;
                    _temp.EmailAddress = customerModel.EmailAddress;
                    _temp.PhoneNumber = customerModel.PhoneNumber;
                    _context.Update<CustomerContactInformation>(_temp);
                    model.Messsage = "Customer Update Successfully";
                }
                else
                {
                    _context.Add<CustomerContactInformation>(customerModel);
                    model.Messsage = "Customer Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        /// <summary>
        /// delete employees
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public ResponseModel DeleteCustomer(string ssn)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                CustomerContactInformation _temp = GetCustomerDetailsBySSN(ssn);
                if (_temp != null)
                {
                    _context.Remove<CustomerContactInformation>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Customer Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Customer Not Found";
                }

            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

    }
}
