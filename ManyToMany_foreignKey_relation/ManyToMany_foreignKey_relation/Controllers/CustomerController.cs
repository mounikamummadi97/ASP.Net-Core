using ManyToMany_foreignKey_relation.IDataRepository;
using ManyToMany_foreignKey_relation.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManyToMany_foreignKey_relation.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IDataRepository<Customer> _dataRepository;
        public CustomerController(IDataRepository<Customer> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Customer> Customersdata = _dataRepository.GetAll();
            return Ok(Customersdata);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Customer customer = _dataRepository.Get(id);
            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer is null.");
            }
            _dataRepository.Add(customer);
            return Ok(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("customer is null.");
            }
            Customer customerToUpdate = _dataRepository.Get(id);
            if (customerToUpdate == null)
            {
                return NotFound("The Customer record couldn't be found.");
            }
            _dataRepository.Update(customerToUpdate, customer);
            return NoContent();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Customer customer = _dataRepository.Get(id);
            if (customer == null)
            {
                return NotFound("The customer record couldn't be found.");
            }
            _dataRepository.Delete(customer);
            return NoContent();
        }
    }
}
