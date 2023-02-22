using Employee_DBLayer.Model;
using Interface.DataRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _3Tier_Architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
         readonly IDataRepository<Employee> _iDataRepository;
        private IDataRepository<EmployeeController> iDataRepository;
        private IDataRepository<EmployeeController> iDataRepository1;

        public EmployeeController(IDataRepository<Employee> iDataRepository)
        {
            _iDataRepository = iDataRepository;
        }

       }

        //public EmployeeController(IDataRepository<EmployeeController> _iDataRepository)
        //{
        //    iDataRepository = _iDataRepository;
        //}

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var list = _iDataRepository.GetAllEmployees();
            //SaveChangesCompletedEventData. Ok(list);
            return list;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Employee Get(int id, object @object)
        {
            var record = _iDataRepository.GetEmployeebyId(id);
            return record;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Employee value)
        {
            if (value == null)
            {
                BadRequest("Value does not exist");
            }
            else { 
            _iDataRepository.Add(value); 
            } 
        }
    

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Employee value)

    {
            var record = _iDataRepository.GetEmployeebyId(id);
        _iDataRepository.Update(record, value);

    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var record = _iDataRepository.GetEmployeebyId(id);
            if (record != null)
            {
                _iDataRepository.Delete(id);

                
            }
            
        }
    }
}
