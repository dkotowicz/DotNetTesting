using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVC_ASP.Controllers;
using MVC_ASP.Models;
using System;
using System.Web.Mvc;

namespace MVC_ASP.Tests.Tests
{
    [TestClass]
    public class AdresMoqTests
    {
        [TestMethod]
        public void TestDisplayByIdMoq()
        {
            Adres adres = new Adres();
            adres.adresId = 5;
            adres.miasto = "Warszawa";
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.FindAdresById(2)).Returns(adres);
            var controller = new AdresController(context.Object);
           
            var result = controller.DisplayById(2) as ViewResult;

            Assert.AreEqual("Display", result.ViewName);
            var resultAdres = (Adres)result.Model;
            Assert.AreEqual("Warszawa", resultAdres.miasto);
        }

        [TestMethod]
        public void TestEditAdresMoq()
        {
            Adres adres = new Adres();
            adres.adresId = 5;
            adres.miasto = "Gdańsk";
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.FindAdresById(2)).Returns(adres);
            var controller = new AdresController(context.Object);
            

            var result = controller.Edit(2) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
            var resultAdres = (Adres)result.Model;
            Assert.AreEqual("Gdańsk", resultAdres.miasto);
        }

        [TestMethod]
        public void TestEditConfAdresMoq()
        {
            Adres adres = new Adres();
            adres.miasto = "Gdańsk";
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.FindAdresById(2)).Returns(adres);
            context.Setup(s => s.SaveChanges()).Returns(0);
            var controller = new AdresController(context.Object);
           
            adres.miasto = "Warszawa";
            adres.kodPocztowy = "80-292";
            adres.adresId = 2;
            var result = controller.Edit(adres) as RedirectToRouteResult;

            Assert.AreEqual("All", result.RouteValues["Action"]);
            Assert.AreEqual("Person", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestEditModelNotValidMoq()
        {
            Adres adres = new Adres();
            adres.miasto = "Gdańsk";
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.FindAdresById(2)).Returns(adres);
            context.Setup(s => s.SaveChanges()).Returns(0);
            var controller = new AdresController(context.Object);
            adres.miasto = "Warszawa";
            adres.kodPocztowy = "80-292";
            adres.adresId = 2;

            controller.ViewData.ModelState.AddModelError("imie", "Podałeś zły nr mieszkania");
            var result = (ViewResult)controller.Edit(adres);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DisplayByIdExceptionMoq()
        {
            /*Adres adres = new Adres();
            adres.adresId = 5;
            adres.miasto = "Warszawa";*/
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();

            context.Setup(x => x.FindAdresById(2)).Returns((Adres)null);
            var controller = new AdresController(context.Object);

            var result = controller.DisplayById(2) as ViewResult;

            Assert.AreEqual("Display", result.ViewName);
            var resultAdres = (Adres)result.Model;
            Assert.AreEqual(typeof(Exception), result.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void EditViewExceptionMoq()
        {
            /*Adres adres = new Adres();
            adres.adresId = 5;
            adres.miasto = "Gdańsk";*/
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.FindAdresById(2)).Returns((Adres)null);
            var controller = new AdresController(context.Object);
            var result = controller.Edit(25) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
            var resultAdres = (Adres)result.Model;
            Assert.AreEqual(typeof(Exception), result.GetType());
        }
    }
}
