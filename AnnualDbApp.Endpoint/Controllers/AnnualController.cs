using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFZV31_HFT_2023241_AnnualDbApp.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnualController : ControllerBase
    {
        // GET: api/<AnnualController2>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AnnualController2>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AnnualController2>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AnnualController2>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AnnualController2>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
