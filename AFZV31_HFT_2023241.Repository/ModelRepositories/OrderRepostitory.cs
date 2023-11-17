using AFZV31_HFT_2023241.Models;
using AFZV31_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFZV31_HFT_2023241.Repository
{
    public class OrderRepostitory : Repository<Order>
    {
        public OrderRepostitory(AnnualDbContext ctx) : base(ctx)
        {
        }

        public override Order Read(int id)
        {
            return ctx.Orders.FirstOrDefault(t=> t.OrderId ==id);
        }

        public override void Update(Order item)
        {
            var old = Read(item.OrderId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }

}
