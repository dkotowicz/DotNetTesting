using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_ASP.Controllers;
using MVC_ASP.Models;
using MVC_ASP.Tests.Doubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC_ASP.Tests.Tests
{
    [TestClass]
    public class AdresControllerTest
    {
        [TestMethod]
        public void TestController()
        {
            var context = new FakePersonSharingContext();
            var controller = new AdresController();
        }
        [TestMethod]
        public void TestDisplayById()
        {
            var context = new FakePersonSharingContext();
            context.Adreses = new[]
            {
                new Adres { adresId = 1, miasto="Gdańsk", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"},
                 new Adres { adresId = 2, miasto="Warszawa", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"},
                  new Adres { adresId = 3, miasto="Gdańsk", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"}
            }.AsQueryable();

            var controller = new AdresController(context);
            var result = controller.DisplayById(2) as ViewResult;

            Assert.AreEqual("Display", result.ViewName);
            var resultAdres = (Adres)result.Model;
            Assert.AreEqual("Warszawa", resultAdres.miasto);
        }

        [TestMethod]
        public void TestEditAdres()
        {
            var context = new FakePersonSharingContext();
            context.Adreses = new[]
            {
                new Adres { adresId = 1, miasto="Gdańsk", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"},
                 new Adres { adresId = 2, miasto="Warszawa", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"},
                  new Adres { adresId = 3, miasto="Gdańsk", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"}
            }.AsQueryable();

            var controller = new AdresController(context);
            var result = controller.Edit(2) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
            var resultAdres = (Adres)result.Model;
            Assert.AreEqual("Warszawa", resultAdres.miasto);
        }

        [TestMethod]
        public void TestEditConfAdres()
        {
            var context = new FakePersonSharingContext();
            context.Adreses = new[]
            {
                new Adres { adresId = 1, miasto="Gdańsk", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"},
                 new Adres { adresId = 2, miasto="Warszawa", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"},
                  new Adres { adresId = 3, miasto="Gdańsk", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"}
            }.AsQueryable();

            Adres adres = new Adres();

            adres.miasto = "Poznań";
            adres.ulica = "Słowackiego";
            adres.nrMieszkania = "2";
            adres.nrBloku = "56D";
            adres.kodPocztowy = "90-765";
            adres.adresId = 2;
            var controller = new AdresController(context);
            var result = controller.Edit(adres) as RedirectToRouteResult;

            Assert.AreEqual("All", result.RouteValues["Action"]);
            Assert.AreEqual("Person", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestEditModelNotValid()
        {
            var context = new FakePersonSharingContext();
            context.Adreses = new[]
            {
                new Adres { adresId = 1, miasto="Gdańsk", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"},
                 new Adres { adresId = 2, miasto="Warszawa", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"},
                  new Adres { adresId = 3, miasto="Gdańsk", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"}
            }.AsQueryable();

            Adres adres = new Adres();

            adres.miasto = "Poznań";
            adres.ulica = "Słowackiego";
            adres.nrMieszkania = "2D";
            adres.nrBloku = "56D";
            adres.kodPocztowy = "90-765";
            adres.adresId = 2;
            var controller = new AdresController(context);
            controller.ViewData.ModelState.AddModelError("imie", "Podałeś zły nr mieszkania");
            var result = (ViewResult)controller.Edit(adres);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DisplayByIdException()
        {
            var context = new FakePersonSharingContext();
            context.Adreses = new[]
            {
                new Adres { adresId = 1, miasto="Gdańsk", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"},
                 new Adres { adresId = 2, miasto="Warszawa", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"},
                  new Adres { adresId = 3, miasto="Gdańsk", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"}
            }.AsQueryable();

            var controller = new AdresController(context);
            var result = controller.DisplayById(25);
            Assert.AreEqual(typeof(Exception), result.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void EditViewException()
        {
            var context = new FakePersonSharingContext();
            context.Adreses = new[]
            {
                new Adres { adresId = 1, miasto="Gdańsk", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"},
                 new Adres { adresId = 2, miasto="Warszawa", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"},
                  new Adres { adresId = 3, miasto="Gdańsk", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"}
            }.AsQueryable();

            var controller = new AdresController(context);
            var result = controller.Edit(25);
            Assert.AreEqual(typeof(Exception), result.GetType());
        }
    }
}
