using AFZV31_HFT_2023241.Endpoint.Services;
using AFZV31_HFT_2023241.Logic;
using AFZV31_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFZV31_HFT_2023241_AnnualDbApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnnualController : ControllerBase
    {
        IAnnualLogic logic;

        IHubContext<SignalRHub> hub;

        public AnnualController(IAnnualLogic logic, IHubContext<SignalRHub> hub)
        { 
            this.logic = logic;
            this.hub = hub;
        }

        
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
            this.hub.Clients.All.SendAsync ("AnnualCreated",value);
        }

        
        [HttpPut] // [HttpPut("{id}")]
        public void Update([FromBody] Annual value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("AnnualUpdated", value);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var DeleteCandidate= this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("AnnualDeleted", DeleteCandidate);
        }
    }
}
