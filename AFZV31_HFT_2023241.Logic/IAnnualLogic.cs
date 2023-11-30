using AFZV31_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AFZV31_HFT_2023241.Logic
{
    public interface IAnnualLogic
    {
        IQueryable AreaCalc(string shortname); //??
        void AreaCalc2(); //??
        IQueryable PcsCalc(string annualCode);

        void Create(Annual item);
        void Delete(int id);

        Annual Read(int id);
        IQueryable<Annual> ReadAll();
        void Update(Annual item);
    }
}
