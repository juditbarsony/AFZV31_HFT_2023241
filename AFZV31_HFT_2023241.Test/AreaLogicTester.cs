using AFZV31_HFT_2023241.Logic;
using AFZV31_HFT_2023241.Models;
using AFZV31_HFT_2023241.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFZV31_HFT_2023241.Test
{
    [TestFixture]
    public class FakeAreaRepository : IRepository<Area>
    {
        public FakeAreaRepository()
        {
        }

        public void Create(Area item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Area Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Area> ReadAll()
        {
            return new List<Area>()
            {
                    new Area("106#10,01#GerMac"),
                    new Area("126#13,03#GerMac")
            }.AsQueryable();
        }

        public void Update(Area item)
        {
            throw new NotImplementedException();
        }
    }
    public class AreaLogicTester
    {
        AreaLogic logic;
        [SetUp]
        public void Init()
        {
            logic = new AreaLogic(new FakeAreaRepository());
        }
        [Test]
        public void Test1()
        {

        }
    }
}
