using Foreignkey_Creating_APIController.IDataRepository;
using Foreignkey_Creating_APIController.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Foreignkey_Creating_APIController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customer_ProductController : ControllerBase
    {
        private readonly IDataRepository<CustomerProduct> _dataRepository;
        public Customer_ProductController(IDataRepository<CustomerProduct> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/<Customer_ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<CustomerProduct> CustomersProductsdata = _dataRepository.GetAll();
            return Ok(CustomersProductsdata);
            
        }

        // GET api/<Customer_ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            CustomerProduct customerproduct = _dataRepository.Get(id);
            if (customerproduct == null)
            {
                return NotFound("The customerproduct record couldn't be found.");
            }
            return Ok(customerproduct);
        }

        // POST api/<Customer_ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerProduct customerproduct)
        {
            if (customerproduct == null)
            {
                return BadRequest("customerproduct is null.");
            }
            _dataRepository.Add(customerproduct);
            return Ok(customerproduct);
        }

        // PUT api/<Customer_ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerProduct customer)
        {
            if (customer == null)
            {
                return BadRequest("customer is null.");
            }
            CustomerProduct customerToUpdate = _dataRepository.Get(id);
            if (customerToUpdate == null)
            {
                return NotFound("The CustomerProduct record couldn't be found.");
            }
            _dataRepository.Update(customerToUpdate, customer);
            return NoContent();
        }

        // DELETE api/<Customer_ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            CustomerProduct customer = _dataRepository.Get(id);
            if (customer == null)
            {
                return NotFound("The customer record couldn't be found.");
            }
            _dataRepository.Delete(customer);
            return NoContent();
        }
    }

   
}
