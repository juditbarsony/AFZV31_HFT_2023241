using AFZV31_HFT_2023241.Logic;
using AFZV31_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFZV31_HFT_2023241_AnnualDbApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnnualController : ControllerBase
    {
        IAnnualLogic logic;
        public AnnualController(IAnnualLogic logic)
        { this.logic = logic; }

        
        [HttpGet]
        public IEnumerable<Annual> ReadAll()
        {
            return this.logic.ReadAll();
        }

        
        [HttpGet("{id}")]
        public Annual Read(int id)
        {
            return this.logic.Read(id);
        }

        
        [HttpPost]
        public void Create([FromBody] Annual value)
        {
            this.logic.Create(value);
        }

        
        [HttpPut] // [HttpPut("{id}")]
        public void Update([FromBody] Annual value)
        {
            this.logic.Update(value);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
