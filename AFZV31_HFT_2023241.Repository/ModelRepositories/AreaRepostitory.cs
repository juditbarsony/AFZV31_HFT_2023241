using AFZV31_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFZV31_HFT_2023241.Repository
{
    public class AreaRepostitory : Repository<Area>, IRepository<Area>
    {
        public AreaRepostitory(AnnualDbContext ctx) : base(ctx)
        {
        }

        public override Area Read(int id)
        {
            return ctx.Areas.FirstOrDefault(t => t.AreaId == id);
        }

        public override void Update(Area item)
        {
            var old = Read(item.AreaId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
