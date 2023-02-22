using BAL.DataRepository;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solidprinciples__jwtAuth__3_tier_architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IDataRepository<Customer> IdataRepository;
        private readonly IDataRepository1<Customer> IdataRepository1;
        public CustomerController(IDataRepository<Customer> _IdataRepository, IDataRepository1<Customer> _IdataRepository1) 
        {
            IdataRepository = _IdataRepository;

            IdataRepository1 = _IdataRepository1;

        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var CustomerList = IdataRepository.GetAll();    
            return CustomerList;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return IdataRepository.Get(id);
        }
       
        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer value)
        {
            IdataRepository1.Add(value);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer value)
        {
            var result = IdataRepository.Get(id);
            IdataRepository1.Update(result, value);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var customer = IdataRepository.Get(id);
            IdataRepository1.Delete(customer);
        }
    }
}
