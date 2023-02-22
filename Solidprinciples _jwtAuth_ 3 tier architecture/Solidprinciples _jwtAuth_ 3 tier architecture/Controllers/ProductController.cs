using BAL.DataRepository;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solidprinciples__jwtAuth__3_tier_architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IDataRepository<Product> IdataRepository;
        private readonly IDataRepository1<Product> IdataRepository1;
        private readonly IDataRepository2<Product> IdataRepository2;
        public ProductController(IDataRepository<Product> _IdataRepository, IDataRepository1<Product> idataRepository1, IDataRepository2<Product> idataRepository2)//, IConfiguration configuration)
        {
            IdataRepository = _IdataRepository;
            IdataRepository1 = idataRepository1;

            IdataRepository2 = idataRepository2;

        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            var products = IdataRepository.GetAll();
            return products;       
                }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Getid(int id)
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
            var result = IdataRepository.Get(id);
            IdataRepository1.Delete(result);

        }
        
        [HttpGet("Include All")]
        public IActionResult GetAllInclude()
        {
            IEnumerable<Product> Products2 = IdataRepository2.GetAll();
            if (Products2 != null)
            {
                return Ok(Products2);
            }
            else
            {
                return BadRequest("Data Not Found....");
            }
        }
        [HttpGet("Include by Id")]
        public IActionResult GetInclude(int id)
        
        {
            var Result = IdataRepository2.Get(id);
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