using BAL.DataRepository;
using DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Three_Tier_Architecture.Controllers
{
    [Authorize] 
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IDataRepository<Customer> IdataRepository; 
       // private IConfiguration _configuration;
        public CustomerController(IDataRepository<Customer> _IdataRepository)//, IConfiguration configuration)
        {
            IdataRepository = _IdataRepository;
            //_configuration = configuration;

        }
        //up
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var CustomerList = IdataRepository.GetAllCustomers();
            return CustomerList;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer GetCustomerById(int id)
        {
            return IdataRepository.GetCustomerById(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void AddCustomer([FromBody] Customer customer)
        {
            IdataRepository.AddCustomer(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void UpdateCustomer(int id, [FromBody]   Customer entity)
        {
            var result = IdataRepository.GetCustomerById(id);
            IdataRepository.Update(result , entity);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
             IdataRepository.Delete(id);
        }
    }
    }

    
