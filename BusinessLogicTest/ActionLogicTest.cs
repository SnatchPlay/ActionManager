using System;
using DTO;
using BusinessLogic;
using DAL;
using DAL.Repository;
using Moq;
using System.Transactions;
using System.Collections.Generic;

using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class BusinessLogicTest
    {
        [TestMethod]
        public void GetPastActionTest()
        {
            var action = new ActionLogic();
            DateTime start = Convert.ToDateTime("06.04.2020");
            DateTime end = Convert.ToDateTime("05.04.2021");
            ActionDTO PastAction = new ActionDTO("PastAction", 45, 1, start, end, DateTime.Now, DateTime.Now);
            ActionRep action1 = new ActionRep();
            action1.AddObj(PastAction);
            List<ActionDTO> action2 = new List<ActionDTO>();
            action2 = action1.GetEnteties();
            List<ActionDTO> Pastactions = new List<ActionDTO>();
            Pastactions = action.GetPastAction();
            Assert.AreEqual(Pastactions, action2);

        }
    }
}    
