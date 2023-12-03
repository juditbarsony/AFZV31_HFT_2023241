using AFZV31_HFT_2023241.Logic;
using AFZV31_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
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
        public StatController(IAnnualLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet("{annualCode}")]
        public IQueryable AreaCalc(string annualCode)
        {
            return logic.AreaCalc(annualCode);
        }

        [HttpGet]
        public IQueryable AreaCalc2()
        {
            return this.logic.AreaCalc2();
        }
        [HttpGet]
        public IEnumerable<AnnualPriceResult> AnnualPrice()
        { 
        return this.logic.AnnualPrice();
        }
        [HttpGet]
        public IEnumerable<double> AnnualPricePerCompany(string company)
        {
            return this.logic.AnnualPricePerCompany(company);
        }

        [HttpGet]
        public IEnumerable<SumResult> AreaPrice()
        {
            return this.logic.AreaPrice();
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
