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
using Moq;


namespace BLLTests
{
    [TestClass]
    public class TourActionsTests
    {
        TourActions ta = new TourActions();
        Context context = new Context();
        private UnitOfWork uow;

        [TestMethod]
        public void GetTours()
        {
            var mock = new Mock<TourActions>();
            uow = new UnitOfWork(context, new ContextRepository<Role>(context), new ContextRepository<User>(context), new ContextRepository<Tour>(context), new ContextRepository<City>(context));

            List<MTour> list = new List<MTour>();

            mock.Setup(a => a.GetTours()).Returns(list);
            Assert.That(mock.Object.GetTours(), Is.Not.Null);
        }

        [TestMethod]
        public void GetTourById()
        {
            var mock = new Mock<TourActions>();
            uow = new UnitOfWork(context, new ContextRepository<Role>(context), new ContextRepository<User>(context), new ContextRepository<Tour>(context), new ContextRepository<City>(context));

            MTour bt = new MTour() { NameTour = "Egypt", TourID = 3 };

            mock.Setup(a => a.GetTourById(3)).Returns(bt);
            mock.Setup(a => a.AddTour(bt));

            Assert.That(mock.Object.GetTourById(3), Is.EqualTo(bt));
        }



        [TestMethod]
        public void AddTour()
        {
            var mock = new Mock<TourActions>();
            uow = new UnitOfWork(context, new ContextRepository<Role>(context), new ContextRepository<User>(context), new ContextRepository<Tour>(context), new ContextRepository<City>(context));

            MTour bt = new MTour() { NameTour = "Egypt", TourID = 3 };

            mock.Setup(a => a.AddTour(bt)).Returns(true);

            Assert.That(mock.Object.AddTour(bt), Is.True);
        }



        [TestMethod]
        public void DeleteTourByID()
        {
            var mock = new Mock<TourActions>();
            uow = new UnitOfWork(context, new ContextRepository<Role>(context), new ContextRepository<User>(context), new ContextRepository<Tour>(context), new ContextRepository<City>(context));

            MTour bt = new MTour() { NameTour = "Egypt", TourID = 5 };

            mock.Setup(a => a.AddTour(bt));
            mock.Setup(a => a.DeleteTourByID(5)).Returns(true);

            Assert.That(mock.Object.DeleteTourByID(5), Is.True);
        }



        [TestMethod]
        public void ChangeTour()
        {
            var mock = new Mock<TourActions>();
            uow = new UnitOfWork(context, new ContextRepository<Role>(context), new ContextRepository<User>(context), new ContextRepository<Tour>(context),
                new ContextRepository<City>(context));

            MTour newm1 = new MTour { NameTour = "b" };

            mock.Setup(a => a.ChangeTour(newm1)).Returns(true);


            Assert.That(mock.Object.ChangeTour(newm1), Is.True);
        }
    }
}
