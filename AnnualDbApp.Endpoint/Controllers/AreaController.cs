using AFZV31_HFT_2023241.Logic;
using AFZV31_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AFZV31_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AreaController
    {
        IAreaLogic logic;
        public AreaController(IAreaLogic logic)
        { this.logic = logic; }


        [HttpGet]
        public IEnumerable<Area> ReadAll()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Area Read(int id)
        {
            return this.logic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Area value)
        {
            this.logic.Create(value);
        }


        [HttpPut("{id}")]
        public void Update([FromBody] Area value)
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
