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

        //[HttpGet("{annualCode}")]
        //public IEnumerable<T> PcsCalc()
        //{

        //    return logic.PcsCalc();
        //}


    }
}
