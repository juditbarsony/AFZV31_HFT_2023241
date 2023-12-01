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
    public class FakeOrderRepository : IRepository<Order>
    {
        public FakeOrderRepository()
        {
        }

        public void Create(Order item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Order Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> ReadAll()
        {
            return new List<Order>()
            {
                    new Order("14#SedRup#Megyeri#7x7#890"),
                    new Order("15#SedEll#Megyeri#10,5#1490")
            }.AsQueryable();
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
        public class OrderLogicTester
    {
        OrderLogic logic;
        [SetUp]
        public void Init()
        {
            logic = new OrderLogic(new FakeOrderRepository());
        }
        [Test]
        public void Test1()
        {

        }
    }
}
