using AFZV31_HFT_2023241.Models;
using AFZV31_HFT_2023241.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AFZV31_HFT_2023241.Logic
{
    public class AnnualLogic :IAnnualLogic
    {
        IRepository<Annual> repo;
        IRepository<Area> areaRepo; //??
        IRepository<Order> orderRepo; //??


        public AnnualLogic(IRepository<Annual> repo, IRepository<Area> areaRepo, IRepository<Order> orderRepo)  
        {
            this.repo = repo;
            this.orderRepo = orderRepo; //??
            this.areaRepo = areaRepo; //??
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

        /*noncruds
         * 1.bekéri a nevet, kiadja hogy hány m2-en van ilyen növény
         * 2. készít egy gyüjteményt, ami név szerint összegzi a területeket, elmenti egy változóba (sumArea)
         * 3. A sumArea-hoz hozzáadja az Annuals-t (pcsm2). Kimenet egy gyűjtemény (annualPcs): vagy növényenként megmondja hogy hány db-ra van szükség
         * (annualCode a közös, pcsm2*area kellene)
         * 4. Az előző gyűjteményhez hozzácsapja az ordert. annualCode a közös, 
        */


        public IQueryable AreaCalc(string shortname)
        {
            var size = (from t in this.areaRepo.ReadAll()
                        where t.AnnualCode == shortname
                        group t by t.AnnualCode into g
                        select new
                        {
                            areasize = g.Sum(z => z.AreaSize)

                        });
            return size;
        }
      
        public IQueryable AreaCalc2()
        {
            var size = (from t in this.areaRepo.ReadAll()
                        group t by t.AnnualCode into g
                        select new
                        {
                            g.Key,
                            areasize = g.Sum(z => z.AreaSize)

                        });
            return size;
        }
        public Area[] AreaRepo()
        {
             Area[] arepo = areaRepo.ReadAll().ToArray();
            return arepo;
        }
        public Order[] OrderRepo()
        {
            Order[] orepo = orderRepo.ReadAll().ToArray();
            return orepo;
        }
        public Annual[] AnnualRepo()
        {
            Annual[] anrepo = repo.ReadAll().ToArray();
            return anrepo;
        }

        //public IEnumerable<T> AreaCalc2()
        //{
        //    var size = (from t in this.areaRepo.ReadAll()
        //                group t by t.AnnualCode into g
        //                select new AreaCalcResult
        //                {
        //                    shortname=g.Key,
        //                    areaSize = g.Sum(z => z.AreaSize)

        //                });
        //    return (IEnumerable<T>)size;
        //}


        public class AreaCalcResult
        {


            public AreaCalcResult(int annualID, double areaSize, string shortname)
            {
                this.annualID = annualID;
                this.areaSize = areaSize;
                this.shortname = shortname;
            }
            public AreaCalcResult()
            {

                this.areaSize = areaSize;

                this.shortname = shortname;
            }

            public int annualID { get; set; }
            public double areaSize { get; set; }
            public double pieces { get; set; }
            public string shortname { get; set; }

            public override bool Equals(object obj)
            {
                AreaCalcResult b = obj as AreaCalcResult;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.shortname == b.shortname
                        && this.areaSize == b.areaSize
                        && this.annualID == b.annualID;
                }
            }

        }

        //public IEnumerable<T> PcsCalc()
        //{

        //    return (IEnumerable<T>)pcs;

        //}




        //public class FlowerSum
        //{
        //    public int areasize { get; set; }
        //    public string shortname { get; set; }
        //}
        //public IQueryable PcsCalc(string shortname)
        //{
        //    List<Area> list =AreaCalc2();
        //    var pcs = from t in list
        //              join flower in db.Annuals 
        //              on t.AnnualCode equals flower.AnnualCode into result
        //              select new
        //              {
        //                  name = db.Annuals.Select(x=>x.AnnualCode).ToString(),
        //                  size = t.AreaSize,
        //                  pieces = result.Select(x => x.Pcsm2),

        //              };
        //    return  (IQueryable)pcs;
        //}

    }
}
