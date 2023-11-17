using AFZV31_HFT_2023241.Models;
using AFZV31_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFZV31_HFT_2023241.Logic
{
    public class AreaLogic : IAreaLogic
    {
        IRepository<Area> repo;

        public AreaLogic(IRepository<Area> repo)
        {
            this.repo = repo;
        }

        public void Create(Area item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Area Read(int id)
        {
            var area = this.repo.Read(id);
            if (area == null)
            {
                throw new ArgumentException("Area not exists");
            }
            return area;
        }

        public IQueryable<Area> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Area item)
        {
            this.repo.Update(item);
        }
    }
}
