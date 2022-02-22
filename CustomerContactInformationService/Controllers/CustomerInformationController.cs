using CustomerContactInformationService.Models;
using CustomerContactInformationService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerContactInformationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerInformationController : ControllerBase
    {
        ICustomerInformationService _customerService;
        public CustomerInformationController(ICustomerInformationService customerService)
        {
            _customerService  = customerService;
        }

        /// <summary>
        /// get all employess
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var employees = _customerService.GetCustomersList();

                if (employees == null)
                    return NotFound();
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// get employee details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetCustomersById(int id)
        {
            try
            {
                var employees = _customerService.GetCustomerDetailsById(id);
                if (employees == null)
                    return NotFound();
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// save employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveCustomers(CustomerContactInformation customerModel)
        {
            try
            {
                var model = _customerService.SaveCustomer(customerModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// delete employee  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                var model = _customerService.DeleteCustomer(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
