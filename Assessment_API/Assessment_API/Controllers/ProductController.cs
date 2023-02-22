using BAL.DataRepository;
using DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assessment_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IDataRepository<Product> IdataRepository;
        private readonly IDataRepository1<Product> IdataRepository1;
        public ProductController(IDataRepository<Product> _IdataRepository, IDataRepository1<Product> _IdataRepository1)
        {
            IdataRepository = _IdataRepository;

            IdataRepository1 = _IdataRepository1;

        }
        [AllowAnonymous]
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var productList = IdataRepository.GetAll();
            return productList;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return IdataRepository.Get(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            IdataRepository1.Add(value);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            var result = IdataRepository.Get(id);
            IdataRepository1.Update(result, value);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = IdataRepository.Get(id);
            IdataRepository1.Delete(product);
        }
    }

}
