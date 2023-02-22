using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mounika_Demo_Pipeline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MounikaController : ControllerBase
    {
        // GET: api/<MounikaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MounikaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MounikaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MounikaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MounikaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
