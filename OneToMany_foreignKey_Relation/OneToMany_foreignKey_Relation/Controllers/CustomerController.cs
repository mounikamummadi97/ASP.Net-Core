using Microsoft.AspNetCore.Mvc;
using OneToMany_foreignKey_Relation.Model;
using static OneToMany_foreignKey_Relation.DataManager.IdataRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OneToMany_foreignKey_Relation.Controllers
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
        public IEnumerable<Customer> Get()
        {
            return _dataRepository.GetAll();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            var record = _dataRepository.Get(id);
            return record;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer entity)



        {
            _dataRepository.Add(entity);



        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer entity)
        {
            var record = _dataRepository.Get(id);
            _dataRepository.Update(record, entity);



        }


        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var record = _dataRepository.Get(id);
            _dataRepository.Delete(record);
        }
    }
}
