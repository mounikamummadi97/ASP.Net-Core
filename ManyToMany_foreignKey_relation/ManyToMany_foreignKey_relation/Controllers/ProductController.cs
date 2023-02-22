using ManyToMany_foreignKey_relation.IDataRepository;
using ManyToMany_foreignKey_relation.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManyToMany_foreignKey_relation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IDataRepository<Product> _dataRepository;
            public ProductController(IDataRepository<Product> dataRepository)
            {
                _dataRepository = dataRepository;
            }
            // GET: api/<ProductController>
            [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Product> Productsdata = _dataRepository.GetAll();
            return Ok(Productsdata);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = _dataRepository.Get(id);
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("product is null.");
            }
            _dataRepository.Add(product);
            return Ok(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("product is null.");
            }
            Product productToUpdate = _dataRepository.Get(id);
            if (productToUpdate == null)
            {
                return NotFound("The CustomerProduct record couldn't be found.");
            }
            _dataRepository.Update(productToUpdate, product);
            return NoContent();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _dataRepository.Get(id);
            if (product == null)
            {
                return NotFound("The Product record couldn't be found.");
            }
            _dataRepository.Delete(product);
            return NoContent();
        }
    }
}
