using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KeyVault.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeServive<Employee> _dataRepository;
        private IConfiguration _configuration;
        public EmployeeController(IEmployeeServive<Employee> dataRepository, IConfiguration configuration)
        {
            _dataRepository = dataRepository;
            //var kvUrl = configuration["AzureDBConnString"];
            _configuration = configuration;

        }


        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult Get()
        {
            //var kvUrl = _configuration["connectionDB2"];
            IEnumerable<Employee> employees=_dataRepository.GetAll();
            return Ok(employees);

        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            //var cc = _configuration["connectionDB2"];
            var result = _dataRepository.GetEmployeeById(id);
            return result;


        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Employee value)
        {
           // var cc = _configuration["connectionDB2"];
            _dataRepository.Insert(value);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Employee value)
        {
            //var cc = _configuration["connectionDB2"];
            Employee updateEmp=_dataRepository.GetEmployeeById(id);
            _dataRepository.UpdateEmployee(updateEmp, value);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataRepository.DeleteEmployee(id);
        }
    }
}
