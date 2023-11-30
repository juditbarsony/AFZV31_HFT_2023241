using AFZV31_HFT_2023241.Logic;
using AFZV31_HFT_2023241.Models;
using AFZV31_HFT_2023241.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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
              new Annual("3#EchPurpA#Echinacea purpurea ’Alba’#7")
            }.AsQueryable();
        }


        List<Area> expected = new List<Area>()
            {
                    new Area("106#10,01#GerMac"),
                    new Area("126#13,03#GerMac"),
            };


    }
    public class AnnualLogicTester
    {
        AnnualLogic logic;
        [SetUp]
        public void Init()
        {
            logic = new AnnualLogic(new FakeAnnualRepository());
        }
        [Test]
        public void Test1()
        {
            int geraniumArea = logic.AreaCalc("GerMac");
            Assert.That(geraniumArea, Is.EqualTo(23.04));
        }
            

    }
}
