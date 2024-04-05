using AFZV31_HFT_2023241.Endpoint.Services;
using AFZV31_HFT_2023241.Logic;
using AFZV31_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NPOI.SS.Formula.Functions;
using System.Collections.Generic;
using System.Linq;
using static AFZV31_HFT_2023241.Logic.AnnualLogic;

namespace AFZV31_HFT_2023241.Endpoint.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IAnnualLogic logic;


        IHubContext<SignalRHub> hub;

        public StatController(IAnnualLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }


        [HttpGet("{annualCode}")]
        public IEnumerable<AreaCalcResult> AreaCalc(string annualCode)
        {
            return logic.AreaCalc(annualCode);
        }

        [HttpGet]
        public IEnumerable<AnnualPriceResult> AnnualPrice()
        { 
        return this.logic.AnnualPrice();
        }
        [HttpGet]
        public double AnnualPricePerCompany(string company)
        {
            return this.logic.AnnualPricePerCompany(company);
        }

        [HttpGet]
        public double MaxArea()
        {
            return this.logic.MaxArea();
        }


        [HttpGet]
        public double ProjectCost() 
        { 
            return this.logic.ProjectCost(); 
        }

        [HttpGet]
        public Area[] AreaRepo()
        {
            return this.logic.AreaRepo();
        }
        [HttpGet]
        public Order[] OrderRepo()
        {
            return this.logic.OrderRepo();
        }
        [HttpGet]
        public Annual[] AnnualRepo()
        {
            return this.logic.AnnualRepo();
        }




    }
}
