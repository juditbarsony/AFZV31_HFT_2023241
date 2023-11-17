using AFZV31_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFZV31_HFT_2023241.Logic
{
    public interface IOrderLogic
    {
        void Create(Order item);
        void Delete(int id);
        Order Read(int id);
        IQueryable<Order> ReadAll();
        void Update(Order item);
    }
}
