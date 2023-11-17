using AFZV31_HFT_2023241.Models;
using AFZV31_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AFZV31_HFT_2023241.Logic
{
    public class AnnualLogic : IAnnualLogic
    {
        IRepository<Annual> repo;

        public AnnualLogic(IRepository<Annual> repo)
        {
            this.repo = repo;
        }

        public void Create(Annual item)
        {
            if (item.AnnualName.Length < 3)
            {
                throw new ArgumentException("title too short...");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Annual Read(int id)
        {
            var annual = this.repo.Read(id);
            if (annual == null)
            {
                throw new ArgumentException("Annual not exists");
            }
            return annual;
        }

        public IQueryable<Annual> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Annual item)
        {
            this.repo.Update(item);
        }
    }
}
