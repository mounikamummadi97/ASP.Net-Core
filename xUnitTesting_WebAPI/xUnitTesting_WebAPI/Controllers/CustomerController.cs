using Microsoft.AspNetCore.Mvc;
using xUnitTesting_WebAPI.DataManager;
using xUnitTesting_WebAPI.Interface;
using xUnitTesting_WebAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace xUnitTesting_WebAPI.Controllers
{
    [Route("[controller]/[Action]")]
   // [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IDataRepository IdataRepository;
        public CustomerController(IDataRepository _IdataRepository)
        {
            IdataRepository = _IdataRepository;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> CustomerList()
        {
            var CustomerList = IdataRepository.GetCustomerList();
            return CustomerList;
            
        }

        // GET api/<CustomerController>/5
        [HttpGet]
        
        public Customer GetCustomerById(int id)
        {
            return IdataRepository.GetCustomerById(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void AddCustomer([FromBody] Customer customer)
        {
            IdataRepository.Insert(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        public void UpdateCustomer(int id, [FromBody] Customer customer)
        {
             IdataRepository.UpdateCustomer(customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete]
        public bool DeleteCustomer(int id)
        {
            return IdataRepository.DeleteCustomer(id);
        }
    }
}
