using Microsoft.AspNetCore.Mvc;
using WebAPI_ForeignKey_Relations.Data;
using WebAPI_ForeignKey_Relations.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_ForeignKey_Relations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerControllers : ControllerBase
    {
        private readonly API_DBContext dbContext;
        public CustomerControllers(API_DBContext dBContext)
        {
            dbContext = dBContext;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return dbContext.Customers;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            var ID = dbContext.Customers.Find(id);
            return ID;

        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            var result = dbContext.Customers.Add(customer);

            dbContext.SaveChanges();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            var ID = dbContext.Customers.Find(id);
            ID.CustomerName = customer.CustomerName;
            ID.CustomerAddress = customer.CustomerAddress;
            ID.CustomerAge = customer.CustomerAge;
            dbContext.SaveChanges();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var result = dbContext.Customers.Find(id);
            dbContext.Customers.Remove(result);
            dbContext.SaveChanges();
        }
    }
}
