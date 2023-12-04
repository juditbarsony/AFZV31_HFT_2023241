using AFZV31_HFT_2023241.Models;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static AFZV31_HFT_2023241.Logic.AnnualLogic;

namespace AFZV31_HFT_2023241.Logic
{
    public interface IAnnualLogic
    {
        IEnumerable<AreaCalcResult> AreaCalc(string shortname);


        IEnumerable<AnnualPriceResult> AnnualPrice();

       double AnnualPricePerCompany(string company);

        //IEnumerable<SumResult> AreaPrice();

        public double MaxArea();

        public double ProjectCost();

        Area[] AreaRepo();
        Order[] OrderRepo();
        Annual[] AnnualRepo();



        void Create(Annual item);
        void Delete(int id);

        Annual Read(int id);
        IQueryable<Annual> ReadAll();
        void Update(Annual item);
    }
}
