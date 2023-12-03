﻿using AFZV31_HFT_2023241.Models;
using AFZV31_HFT_2023241.Repository;
using MathNet.Numerics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using NPOI.SS.Formula.Functions;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
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

        /*noncruds
         * 1.bekéri a nevet, kiadja hogy hány m2-en van ilyen növény
         * 2. készít egy gyüjteményt, ami név szerint összegzi a területeket, elmenti egy változóba (sumArea)
         * 3. A sumArea-hoz hozzáadja az Annuals-t (pcsm2). Kimenet egy gyűjtemény (annualPcs): vagy növényenként megmondja hogy hány db-ra van szükség
         * (annualCode a közös, pcsm2*area kellene)
         * 4. Az előző gyűjteményhez hozzácsapja az ordert. annualCode a közös, 
        */


        public IQueryable AreaCalc(string shortname) // 1. hány m2 területet ütetnek be az adott növénnyel
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
      
        //public IQueryable AreaCalc2() 
        //{
        //    var size = (from t in this.areaRepo.ReadAll()
        //                group t by t.AnnualCode into g
        //                select new
        //                {
        //                    g.Key,
        //                    areasize = g.Sum(z => z.AreaSize)
        //                });
        //    return size;
        //}

        public IEnumerable<double> MaxArea() //2. a legnagyobb terület 1 féle növényből
        {
            var size = (from t in this.areaRepo.ReadAll()
                        group t by t.AnnualCode into g
                        select new
                        {
                            g.Key,
                            areasize = g.Sum(z => z.AreaSize),
                        });
            var maxsize = size.Max(t=>t.areasize);
            yield return maxsize;
        }


        public IEnumerable<AnnualPriceResult> AnnualPrice() //3. mennyibe kerül az adott növényből 1m2 felület beültetése
        {
            Order[] orepo = orderRepo.ReadAll().ToArray();
            Annual[] anrepo = repo.ReadAll().ToArray();

            var price = from o in orepo
                       join f in anrepo
                       on o.AnnualCode equals f.AnnualCode
                       select new AnnualPriceResult
                       {
                           shortname = f.AnnualCode,
                           company=o.OrderCompany,
                           sum= f.Pcsm2* o.Price
                       };
            return price; 
        }

 

        public IEnumerable<double> AnnualPricePerCompany(string company) //4. az megadott cégtől milyen értékben van szükség a növényekre
        {
            double cost=0;
            var prices= AreaPrice();
            var pricePerComp = from o in prices
                               where o.company == company
                               select o.sum;
            foreach (var pr in pricePerComp)
            {
                cost = cost + pr;
            }

            yield return cost;
        }

        public IEnumerable<SumResult> AreaPrice() 
        {
            Area[] arepo= areaRepo.ReadAll().ToArray();
            var price = AnnualPrice();
            var sum = from o in arepo
                      join a in price
                      on o.AnnualCode equals a.shortname
                      select new SumResult
                      {
                        shortname = a.shortname,
                        company=a.company,
                        sum=a.sum *o.AreaSize
                      };
            return sum;
        }

        public double ProjectCost() //5. a project összköltsége
        {
            var cost = AreaPrice();
            var projectcost = cost.Sum(t => t.sum);
            return Math.Round(projectcost);

        }

        public class AnnualPriceResult
        {
           public string shortname {  get; set; }
           public int sum { get; set; }
          public string company { get; set; }
            public AnnualPriceResult()
            {
                this.shortname = shortname;
                this.company = company;
                this.sum = sum;
            }
        }

        public class AreaCalcResult
        {
            public int annualID { get; set; }
            public double areaSize { get; set; }
            public double pieces { get; set; }
            public string shortname { get; set; }

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

        public class SumResult
        {
            public string shortname { get; set; }
            public double sum { get; set; }
            public string company { get; set; }
            public SumResult()
            {
                this.shortname = shortname;
                this.sum = sum;
                this.company = company; 
            }
        }
    }
}
