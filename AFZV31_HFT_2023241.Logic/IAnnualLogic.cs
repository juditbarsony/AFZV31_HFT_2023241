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
        IQueryable AreaCalc(string shortname);
        IQueryable AreaCalc2(); //??

        IEnumerable<AnnualPriceResult> AnnualPrice();

        IEnumerable<double> AnnualPricePerCompany(string company);

        IEnumerable<SumResult> AreaPrice();

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
