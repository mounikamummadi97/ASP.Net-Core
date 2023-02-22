using BAL.DataRepository;
using DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assessment_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private readonly IDataRepository<Customer> IdataRepository;
        private readonly IDataRepository1<Customer> IdataRepository1;
        private readonly IDataRepository2<Customer> IdataRepository2;
        public CustomerController(IDataRepository<Customer> _IdataRepository, IDataRepository1<Customer> idataRepository1, IDataRepository2<Customer> idataRepository2)
        {
            IdataRepository = _IdataRepository;
            IdataRepository1 = idataRepository1;

            IdataRepository2 = idataRepository2;

        }
        [AllowAnonymous]
        // GET: api/<CustomerController>
        [HttpGet]
      
        public IEnumerable<Customer> GetAll()
        {
            var customers = IdataRepository.GetAll();
            return customers;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        
        public Customer Getid(int id)
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
            var result = IdataRepository.Get(id);
            IdataRepository1.Delete(result);

        }
        [AllowAnonymous]
        [HttpGet("Include All")]
       
        public async Task<IActionResult> GetAllIncludeAsync()
        {
            IEnumerable<Customer> CustomersTable = await IdataRepository2.GetAllAsync();
            if (CustomersTable != null)
            {
                return Ok(CustomersTable);
            }
            else
            {
                return BadRequest("Data Not Found...");
            }
        }
        [HttpGet("Include by Id")]
        
        public async Task<IActionResult> GetIncludeAsync(int id)
        {
            var Result = await IdataRepository2.GetAsync(id);
            if (Result != null)
            {
                return Ok(Result);
            }
            else
            {
                return BadRequest("Data Not Found");
            }
        }
    }
}       
