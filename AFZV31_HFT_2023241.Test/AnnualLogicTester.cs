using AFZV31_HFT_2023241.Logic;
using AFZV31_HFT_2023241.Models;
using AFZV31_HFT_2023241.Repository;
using Moq;
using NPOI.SS.Formula.Functions;
using NUnit.Framework;
using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using static AFZV31_HFT_2023241.Logic.AnnualLogic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static NPOI.POIFS.Crypt.CryptoFunctions;

namespace AFZV31_HFT_2023241.Test
{
    [TestFixture]
    public class AnnualLogicTester
    {
        AnnualLogic logic;
        AreaLogic alogic;
        OrderLogic ologic;

        Mock<IRepository<Annual>> mockAnnualRepo;
        Mock<IRepository<Order>> mockOrderRepo;
        Mock<IRepository<Area>> mockAreaRepo;

        [SetUp]
        public void Init()
        {
            mockAnnualRepo = new Mock<IRepository<Annual>>();
            mockAnnualRepo.Setup(m => m.ReadAll()).Returns(new List<Annual>()
            {
                 new Annual("6#GerMac#Geranium macrorrhizum#9"),
                 new Annual("4#EchPurpM#Echinacea purpurea ’Magnus’#7")
            }.AsQueryable());

            mockAreaRepo = new Mock<IRepository<Area>>();
            mockAreaRepo.Setup(m => m.ReadAll()).Returns(new List<Area>()
            {
                    new Area("106#10,01#GerMac"),
                    new Area("126#13,03#GerMac"),
                    new Area("246#3,39#EchPurpM")
            }.AsQueryable());

            mockOrderRepo = new Mock<IRepository<Order>>();
            mockOrderRepo.Setup(m => m.ReadAll()).Returns(new List<Order>()
            {
                    new Order("4#EchPurpM#Beretvás#9x9#350"),
                    new Order("6#GerMac#Megyeri#9x9#1190"),
            }.AsQueryable());


            logic = new AnnualLogic(mockAnnualRepo.Object, mockAreaRepo.Object, mockOrderRepo.Object);
            alogic = new AreaLogic(mockAreaRepo.Object);
            ologic = new OrderLogic(mockOrderRepo.Object);
        }
        [Test]
        public void AreaCalcTest()
        {
            List<AreaCalcResult> expected = new List<AreaCalcResult>()
                {
                       new AreaCalcResult(){areaSize=23.04}
                };
            var geraniumArea = logic.AreaCalc("GerMac");
            Assert.AreEqual(geraniumArea, expected);
        }

        [Test]
        public void MaxAreaTest()
        {
            var max = logic.MaxArea();
            Assert.That(max, Is.EqualTo(23.04));
        }

        [Test]
        public void AnnualPriceTest()
        {
            var actual = logic.AnnualPrice().ToList();
            var expected = new List<AnnualPriceResult>()
                    {
                new AnnualPriceResult()
                {
                    shortname = "GerMac",
                    company = "Beretvás",
                    sum = 7* 350
                },
                 new AnnualPriceResult()
                {
                    shortname = "EchPurpM",
                    company = "Beretvás",
                    sum = 7* 350
                }
                };

        }
        [Test]
        public void AnnualPricePerCompanyTest()
        {
            var actual = logic.AnnualPricePerCompany("Beretvás");
            var expected =  (350 * 7 * 3.39);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ProjectCostTest()
        {
            var actual = logic.ProjectCost();
            var expected = Math.Round(1190 * 23.04 * 9 + 350 * 7 * 3.39);
            Assert.That(actual, Is.EqualTo(expected));
        }


        [Test]
        public void CreateAnnualTest()
        {
            var annual = new Annual() { AnnualName = "Geranium macrorrhizum" };

            //ACT
            logic.Create(annual);

            //ASSERT
            mockAnnualRepo.Verify(r => r.Create(annual), Times.Once);
        }

        [Test]
        public void CreateAreaTest()
        {
            var area = new Area() { AreaId = 246 };

            //ACT
            alogic.Create(area);

            //ASSERT
            mockAreaRepo.Verify(r => r.Create(area), Times.Once);
        }

        [Test]
        public void CreateOrderTest()
        {
            var order = new Order() { OrderCompany = "Mocsáry" }; 

            //ACT
            ologic.Create(order);

            //ASSERT
            mockOrderRepo.Verify(r => r.Create(order), Times.Once);
        }

        [Test]
        public void DeleteOrderTest()
        {
            int orderid = 2; 

            //ACT
            ologic.Delete(orderid);

            //ASSERT
            mockOrderRepo.Verify(r => r.Delete(orderid), Times.Once);
        }
        [Test]

        public void DeleteAreaTest()
        {
            int areaid = 3;

            //ACT
            alogic.Delete(areaid);

            //ASSERT
            mockAreaRepo.Verify(r => r.Delete(areaid), Times.Once);
        }

    }


}
