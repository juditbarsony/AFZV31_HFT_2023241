using AFZV31_HFT_2023241.Models;
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
            throw new NotImplementedException();
        }
    }

}
