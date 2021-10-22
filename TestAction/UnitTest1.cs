using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using DAL;
using DTO;
using Action = DTO.Action;
using System.Linq;

namespace TestAction
{
    [TestClass]
    public class UnitTest1
    {
        public IRepository<Action> actionRep = new ActionRep();
        public IRepository<Category> categoryRep = new CategoryRep();
        public IRepository<Supply> supplyRep = new SupplyRep();
        [TestMethod]
        public void TestGetAction()
        {
            var actions = actionRep.GetEnteties();
            Assert.IsTrue(actions.Any(a => a.Name == "Monster"));
        }
        [TestMethod]
        public void TestGetSupply()
        {
            var supply = supplyRep.GetEnteties();
            Assert.IsTrue(supply.Any(a => a.Name == "Mirpl"));
        }
        [TestMethod]
        public void TestGetCategory()
        {
            var category = categoryRep.GetEnteties();
            Assert.IsTrue(category.Any(a => a.Name == "Phones"));
        }
        [TestMethod]
        public void TestUpdateDiscountAction()
        {
            float exp = 45;
            actionRep.UpdateField("Action", "Discount", $"{exp}", 1);
            var actual = actionRep.GetEnteties()[0].Discount;
            Assert.IsTrue(actual==exp);
        }
        [TestMethod]
        public void TestDeleteCategory()
        {
            categoryRep.DeleteObject(3);
            var category = categoryRep.GetEnteties();
            bool status = category.Any(a => a.Name == "ForDelete");
            Assert.IsFalse(status);
        }
    }
}

