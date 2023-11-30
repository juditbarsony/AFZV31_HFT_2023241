using AFZV31_HFT_2023241.Logic;
using AFZV31_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        public void AreaCalc2()
        {

            //return this.logic.AreaCalc2();
        }

        [HttpGet("{annualCode}")]
        public IQueryable PcsCalc(string annualCode)
        {

            return logic.PcsCalc(annualCode);
        }


        //[HttpGet("{year}")]
        //public double? AverageRatePerYear(int year)
        //{
        //    return this.logic.GetAverageRatePerYear(year);
        //}

        //[HttpGet]
        //public IEnumerable<MovieLogic.YearInfo> YearStatistics(int year)
        //{
        //    return this.logic.YearStatistics();
        //}
    }
}
