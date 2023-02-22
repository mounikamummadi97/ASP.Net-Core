using API_JWT_Authentication.Interface;
using API_JWT_Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_JWT_Authentication.Controllers
{
    //[Authorize]
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IDataRepository<Customer> _idatarepository;
        public CustomerController(IDataRepository<Customer> idatarepository)
        {
            _idatarepository = idatarepository;

        }
        // GET: api/<CustomerController>
        [HttpGet,Authorize]
        public IEnumerable<Customer> Get()
        {
            var CustomerList = _idatarepository.GetAllCustomer();
            return CustomerList;
            //_idatarepository.GetAllCustomer();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var result=_idatarepository.GetCustomerById(id);
            return Ok("customers");
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer value)
        {
            _idatarepository.AddCustomer(value);
        }

        // PUT api/<CustomerController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{ _idatarepository.UpdateCustomer(customer);
        //}

        //// DELETE api/<CustomerController>/5
        //[HttpDelete("{id}")]
        //public bool Delete(int id)
        //{
        //    return _idatarepository.DeleteCustomer(id);
        //}
    }
}
