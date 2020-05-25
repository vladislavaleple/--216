using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using BLL.Models;
using NUnit.Framework;
using Moq;
using DAL.Models;
using DAL;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;
namespace BLLTests
{
    [TestClass]
    public class UserActionsTests
    {

        TourActions ta = new TourActions();
        Context context = new Context();
        private UnitOfWork uow;

        [TestMethod]
        public void GetUsers()
        {
            var mock = new Mock<UserActions>();
            uow = new UnitOfWork(context, new ContextRepository<Role>(context), new ContextRepository<User>(context), new ContextRepository<Tour>(context), new ContextRepository<City>(context));

            List<MUser> list = new List<MUser>();

            mock.Setup(a => a.GetUsers()).Returns(list);

            Assert.That(mock.Object.GetUsers(), Is.Not.Null);
        }


        [TestMethod]
        public void GetUserById()
        {
            var mock = new Mock<UserActions>();
            uow = new UnitOfWork(context, new ContextRepository<Role>(context), new ContextRepository<User>(context), new ContextRepository<Tour>(context), new ContextRepository<City>(context));


            mock.Setup(a => a.GetUserById(0)).Returns(new MUser());

            Assert.That(mock.Object.GetUserById(0), Is.Not.Null);
        }

        [TestMethod]
        public void AddUser()
        {
            var mock = new Mock<UserActions>();
            uow = new UnitOfWork(context, new ContextRepository<Role>(context), new ContextRepository<User>(context), new ContextRepository<Tour>(context), new ContextRepository<City>(context));

            MUser m = new MUser();
            mock.Setup(a => a.AddUser(m)).Returns(true);

            Assert.That(mock.Object.AddUser(m), Is.True);
        }

        [TestMethod]
        public void DeleteUserByID()
        {
            var mock = new Mock<UserActions>();
            uow = new UnitOfWork(context, new ContextRepository<Role>(context), new ContextRepository<User>(context), new ContextRepository<Tour>(context), new ContextRepository<City>(context));

            MUser m = new MUser();
            mock.Setup(a => a.DeleteUserByID(0)).Returns(true);

            Assert.That(mock.Object.DeleteUserByID(0), Is.True);
        }


    }
}
