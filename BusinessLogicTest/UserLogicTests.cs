//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DTO;
using BusinessLogic;
using DAL;
using DAL.Repository;
using Moq;
using System.Transactions;
using System.Collections.Generic;
using NUnit.Framework;
using System.Text;
using System.Linq;

namespace BusinessLogicTest
{
    [TestFixture]
    public class UserLogicTests
    {
        private Mock<IRepository<User>> userRep;

        protected TransactionScope transactionScope;
        UserLogic userLogic;
        List<User> users;

        [SetUp]
        public void SetUp()
        {
            transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew);

            userRep = new Mock<IRepository<User>>(MockBehavior.Strict);

            userLogic = new UserLogic(); 
            
            CreateUsers();
        }

        private void CreateUsers()
        {
            var user1 = new User("Test1", Encoding.UTF8.GetBytes("Test1"),
                "Test1@mail", new Guid(), DateTime.Now, DateTime.Now, 1);
            var user2 = new User("Test2", Encoding.UTF8.GetBytes("Test2"),
                "Test2@mail", new Guid(), DateTime.Now, DateTime.Now, 2);
            users = new List<User> { user1, user2 };
        }
        [Test]
        public void TestLogin()
        {
            User inPerson = users.First();
            bool resOut = true;
            string login = users[0].Login;
            bool actualRes = userLogic.UserLogin(login, "Test1");

            Assert.AreEqual(actualRes, resOut);
        }
 
    }
}
