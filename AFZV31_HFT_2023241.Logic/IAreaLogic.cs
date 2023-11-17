using AFZV31_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AFZV31_HFT_2023241.Logic
{
    public interface IAreaLogic
    {
        void Create(Area item);
        void Delete(int id);
        Area Read(int id);
        IQueryable<Area> ReadAll();
        void Update(Area item);
    }
}
