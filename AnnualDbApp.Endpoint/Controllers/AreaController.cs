using AFZV31_HFT_2023241.Endpoint.Services;
using AFZV31_HFT_2023241.Logic;
using AFZV31_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace AFZV31_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        IAreaLogic logic;
        IHubContext<SignalRHub> hub;

        public AreaController(IAreaLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }
        //public AreaController(IAreaLogic logic)
        //{ this.logic = logic; }


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
            hub.Clients.All.SendAsync("AreaCreated", value);
        }


        [HttpPut] //[HttpPut("{id}")]
        public void Update([FromBody] Area value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("AreaUpdated", value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var DeleteCandidate = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("AreaDeleted", DeleteCandidate);
        }
    }
}
