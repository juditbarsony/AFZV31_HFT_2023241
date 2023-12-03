using AFZV31_HFT_2023241.Logic;
using AFZV31_HFT_2023241.Models;
using AFZV31_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static AFZV31_HFT_2023241.Logic.AnnualLogic;

namespace AFZV31_HFT_2023241.Test
{

    //public class FakeAnnualRepository : IRepository<Annual>
    //{
    //    public FakeAnnualRepository()
    //    {
    //    }

    //    public void Create(Annual item)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Update(Annual item)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Annual Read(int id)
    //    {
    //        throw new NotImplementedException();
    //    }


    //    public IQueryable<Annual> ReadAll()
    //    {
    //        return new List<Annual>()
    //        {
    //          new Annual("1#AchFiliCG#Achillea filipendulina ’Coronation Gold’#5"),
    //          new Annual("2#BergCord#Bergenia cordifolia#7"),
    //          new Annual("3#GerMac#Echinacea purpurea ’Alba’#7")
    //        }.AsQueryable();
    //    }


    //}

    [TestFixture]
    public class AnnualLogicTester
    {
        AnnualLogic logic;
        Mock<IRepository<Annual>> mockAnnualRepo;
        Mock<IRepository<Order>> mockOrderRepo;

        [SetUp]
        public void Init()
        {
            mockAnnualRepo = new Mock<IRepository<Annual>>();
            mockAnnualRepo.Setup(m => m.ReadAll()).Returns(new List<Annual>()
            {
                          new Annual("1#AchFiliCG#Achillea filipendulina ’Coronation Gold’#5"),
                          new Annual("2#BergCord#Bergenia cordifolia#7"),
                          new Annual("3#GerMac#Echinacea purpurea ’Alba’#7")
            }.AsQueryable());

            mockOrderRepo = new Mock<IRepository<Order>>();
            mockOrderRepo.Setup(m => m.ReadAll()).Returns(new List<Order>()
            {
                        new Order("14#SedRup#Megyeri#7x7#890"),
                        new Order("15#SedEll#Megyeri#10,5#1490")
            }.AsQueryable());



            logic = new AnnualLogic(mockAnnualRepo.Object);

            [Test]

            void Test1()
            {
                List<AreaCalcResult> expected = new List<AreaCalcResult>()
                {
                       new AreaCalcResult(){areaSize=2,shortname="GerMac"}
                };
                var geraniumArea = logic.AreaCalc("GerMac");
                Assert.AreEqual(geraniumArea, expected);
            }

            [Test]
            void CreateAnnualTest()
            {
                var annual = new Annual() { AnnualName = "Bergenia cordifolia" };

                //ACT
                logic.Create(annual);

                //ASSERT
                mockAnnualRepo.Verify(r => r.Create(annual), Times.Once);
            }
        }


    }
}
