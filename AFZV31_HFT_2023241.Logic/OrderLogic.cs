using AFZV31_HFT_2023241.Models;
using AFZV31_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFZV31_HFT_2023241.Logic
{
    public class OrderLogic:IOrderLogic
    {
        IRepository<Order> repo;

        public OrderLogic(IRepository<Order> repo)
        {
            this.repo = repo;
        }

        public void Create(Order item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Order Read(int id)
        {
            var order = this.repo.Read(id);
            if (order == null)
            {
                throw new ArgumentException("Order not exists");
            }
            return order;
        }

        public IQueryable<Order> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Order item)
        {
            this.repo.Update(item);
        }
    }
}
