using AFZV31_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFZV31_HFT_2023241.Repository
{
    public class AnnualRepostitory : Repository<Annual>, IRepository<Annual>
    {
        public AnnualRepostitory(AnnualDbContext ctx) : base(ctx)
        {

        }

        public override Annual Read(int id)
        {
            //return ctx.Annuals.FirstOrDefault(t => t.AnnualId.Equals(id));
            return ctx.Annuals.FirstOrDefault(t => t.AnnualId==id);
        }

        public override void Update(Annual item)
        {
            var old = Read(item.AnnualId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }

    }
}
