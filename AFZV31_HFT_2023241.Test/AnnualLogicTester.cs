using AFZV31_HFT_2023241.Logic;
using AFZV31_HFT_2023241.Models;
using AFZV31_HFT_2023241.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static AFZV31_HFT_2023241.Logic.AnnualLogic;

namespace AFZV31_HFT_2023241.Test
{
    [TestFixture]
    public class FakeAnnualRepository : IRepository<Annual>
    {
        public FakeAnnualRepository()
        {
        }

        public void Create(Annual item)
        {
            throw new NotImplementedException();
        }

        public void Update(Annual item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Annual Read(int id)
        {
            throw new NotImplementedException();
        }


        public IQueryable<Annual> ReadAll()
        {
            return new List<Annual>()
            {
              new Annual("1#AchFiliCG#Achillea filipendulina ’Coronation Gold’#5"),
              new Annual("2#BergCord#Bergenia cordifolia#7"),
              new Annual("3#GerMac#Echinacea purpurea ’Alba’#7")
            }.AsQueryable();
        }


    }

    
    public class AnnualLogicTester
    {
        AnnualLogic logic;
        [SetUp]
        public void Init()
        {
            logic = new AnnualLogic(new FakeAnnualRepository(),new FakeAreaRepository(), new FakeOrderRepository());
        }
        [Test]
        public void Test1()
        {
            //List<AreaCalcResult> expected = new List<AreaCalcResult>()
            //{
            //       new AreaCalcResult(){areaSize=2,shortname="GerMac"}
            //};
            //var geraniumArea = logic.AreaCalc2("GerMac");
            //Assert.AreEqual(geraniumArea, expected);
        }
            

    }
}
