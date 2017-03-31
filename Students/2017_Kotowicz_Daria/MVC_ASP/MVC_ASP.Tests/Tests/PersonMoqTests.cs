using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVC_ASP.Controllers;
using MVC_ASP.Models;
using MVC_ASP.Tests.Doubles;
using MVC_ASP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC_ASP.Tests.Tests
{
    [TestClass]
    public class PersonMoqTests
    {
        [TestMethod]
        public void ChceckViewNameAddMoq()
        {
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            var controller = new PersonController(context.Object);
            var result = controller.Add() as ViewResult;
            Assert.AreEqual("Add", result.ViewName);
        }
        [TestMethod]
        public void ChceckTypeListInAll()
        {
            var ListPerson = new List<Person>();
            ListPerson.Add(new Person { imie = "Kasia", nazwisko = "Kowalska" });
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.Persons).Returns(ListPerson.AsQueryable());
            var controller = new PersonController(context.Object);

            var result = controller.All() as ViewResult;
            var model = ((ViewResult)result).Model as List<Person>;
            Assert.AreEqual(typeof(List<Person>), result.Model.GetType());
            Assert.IsTrue(model.Count == 1);
        }

        [TestMethod]
        public void TestDisplayAllMoqModel()
        {
            var ListPerson = new List<Person>();
            ListPerson.Add(new Person { imie = "Kasia", nazwisko = "Kowalska" });
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.Persons).Returns(ListPerson.AsQueryable());
            var controller = new PersonController(context.Object);

            var result = controller.All() as ViewResult;
            var model = ((ViewResult)result).Model as List<Person>;
            Assert.IsTrue(model.Count == 1);
        }

        [TestMethod]
        public void TestDisplayPersobByIdMoq()
        {
            Person person = new Person();
            person.imie = "Basia";
            person.nazwisko = "Kowalska";
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.FindPersonById(2)).Returns(person);
            var controller = new PersonController(context.Object);

            var result = controller.DisplayById(2) as ViewResult;
            var resultPerson = (Person)result.Model;
            Assert.AreEqual("Basia", resultPerson.imie);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestDisplayPersonExceptionMoq()
        {
            /*Person person = new Person();
            person.imie = "Basia";
            person.nazwisko = "Kowalska";*/
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.FindPersonById(2)).Returns((Person)null);
            var controller = new PersonController(context.Object);

            var result = controller.DisplayById(5) as ViewResult;
            var resultPerson = (Person)result.Model;
            Assert.AreEqual(typeof(Exception), result.GetType());
        }

        [TestMethod]
        public void ChceckTypeListInAllPersonIfPeselNullMoq()
        {
            var ListPerson = new List<Person>();
            ListPerson.Add(new Person { imie = "Kasia", nazwisko = "Kowalska" });
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.PersonOfPeselNull()).Returns(ListPerson.AsQueryable());
            var controller = new PersonController(context.Object);

            var result = controller.DisplayByPeselNull() as ViewResult;
            Assert.AreEqual(typeof(List<Person>), result.Model.GetType());
        }

        [TestMethod]
        public void TestDisplayPersonByPeselNullMoq()
        {
            var ListPerson = new List<Person>();
            ListPerson.Add(new Person { imie = "Kasia", nazwisko = "Kowalska" });
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.PersonOfPeselNull()).Returns(ListPerson.AsQueryable());
            var controller = new PersonController(context.Object);

            var result = controller.DisplayByPeselNull() as ViewResult;
            var modelPersons = (IEnumerable<Person>)result.Model;
            Assert.AreEqual(1, modelPersons.Count());
        }

        [TestMethod]
        public void TestDeleteViewMoq()
        {
            Person person = new Person();
            person.imie = "Basia";
            person.nazwisko = "Kowalska";
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.FindPersonById(2)).Returns(person);
            var controller = new PersonController(context.Object);

            var result = controller.Delete(2) as ViewResult;
            var resultPerson = (Person)result.Model;
            Assert.AreEqual("Basia", resultPerson.imie);
        }

        [TestMethod]
        public void TestDeletePersonIsNotNullMoq()
        {
            Person person = new Person();
            person.imie = "Basia";
            person.nazwisko = "Kowalska";
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.FindPersonById(2)).Returns(person);
            var controller = new PersonController(context.Object);

            var result = controller.Delete(2) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod] //Moq nie ma sensu
        public void ChceckViewBackAdd()
        {
            var context = new FakePersonSharingContext();
            var controller = new PersonController(context);
            var result = controller.Add() as ViewResult;
            Assert.IsTrue(result.ViewBag.Napis == "Dodawanie nowej osoby");
        }

        [TestMethod]
        public void TestEditPersonViewMoq()
        {
            Person person = new Person();
            person.imie = "Basia";
            person.nazwisko = "Kowalska";
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.FindPersonById(2)).Returns(person);
            var controller = new PersonController(context.Object);

            var result = controller.Edit(2);
            ViewResult p = (ViewResult)controller.Edit(2);
            var view = p.ViewName;
            Assert.AreEqual("Edit", view);
        }

        [TestMethod]
        public void TestDeleteHttpMoq()
        {
            Person person = new Person();
            person.imie = "Basia";
            person.nazwisko = "Kowalska";
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.FindPersonById(2)).Returns(person);
            var controller = new PersonController(context.Object);

            var result = controller.Delete(25);
            Assert.AreEqual(typeof(HttpNotFoundResult), result.GetType());
        }

        [TestMethod]
        public void TestEditHttpMoq()
        {
            Person person = new Person();
            person.imie = "Basia";
            person.nazwisko = "Kowalska";
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.FindPersonById(2)).Returns(person);
            var controller = new PersonController(context.Object);

            var result = controller.Edit(25);
            Assert.AreEqual(typeof(HttpNotFoundResult), result.GetType());
        }

        [TestMethod]
        public void TestDeleteConfMoq()
        {
            Person person = new Person();
            person.imie = "Basia";
            person.nazwisko = "Kowalska";
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.FindPersonById(2)).Returns(person);
            context.Setup(s => s.SaveChanges()).Returns(0);
            var controller = new PersonController(context.Object);
            var result = controller.DeleteConfirmed(2) as RedirectToRouteResult;

            Assert.AreEqual("All", result.RouteValues["Action"]);
            Assert.AreEqual("Person", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestAddConf()
        {
            PersonAdres personAdd = new PersonAdres();
            personAdd.imie = "Kasia";
            personAdd.kodPocztowy = "80-292";
            personAdd.miasto = "Gdańsk";
            personAdd.nazwisko = "Kowalska";
            personAdd.nrBloku = "56";
            personAdd.ulica = "Focha";
            personAdd.nrMieszkania = "6";

            Person person = new Person();
            person.imie = "Kasia";
            person.nazwisko = "Kowalska";

            Adres adres = new Adres();
            adres.miasto = "Warszawa";
            adres.adresId = 5;

            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.Add(adres)).Returns(adres);
            context.Setup(s => s.Add(person)).Returns(person);
            var controller = new PersonController(context.Object);
            var result = controller.Add(personAdd) as RedirectToRouteResult;

            Assert.AreEqual("All", result.RouteValues["Action"]);
            Assert.AreEqual("Person", result.RouteValues["Controller"]);

        }

        [TestMethod]
        public void TestEditPersonMoq()
        {
            Person person = new Person();
            person.imie = "Basia";
            person.nazwisko = "Kowalska";
            person.personId = 5;
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.FindPersonById(2)).Returns(person);
            context.Setup(x => x.SaveChanges()).Returns(0);
            var controller = new PersonController(context.Object);
            person.personId = 2;
            var result = controller.Edit(person) as RedirectToRouteResult;

            Assert.AreEqual("All", result.RouteValues["Action"]);
            Assert.AreEqual("Person", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestAddModelNotValidMoq()
        {
            PersonAdres personAdd = new PersonAdres();
            personAdd.imie = "Kasia";
            personAdd.kodPocztowy = "80-292";
            personAdd.miasto = "Gdańsk";
            personAdd.nazwisko = "Kowalska";
            personAdd.nrBloku = "56";
            personAdd.ulica = "Focha";
            personAdd.nrMieszkania = "6";

            Person person = new Person();
            person.imie = "Kasia";
            person.nazwisko = "Kowalska";

            Adres adres = new Adres();
            adres.miasto = "Warszawa";
            adres.adresId = 5;

            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.Add(adres)).Returns(adres);
            context.Setup(s => s.Add(person)).Returns(person);
            var controller = new PersonController(context.Object);

            controller.ViewData.ModelState.AddModelError("imie", "Podaj imię");
            var result = (ViewResult)controller.Add(personAdd);
            Assert.AreEqual("Add", result.ViewName);
        }

        [TestMethod]
        public void TestEditPersonModelNotValid()
        {
            Person person = new Person();
            person.imie = "Basia";
            person.nazwisko = "Kowalska";
            person.personId = 5;
            Mock<IPersonSharingContext> context = new Mock<IPersonSharingContext>();
            context.Setup(x => x.FindPersonById(2)).Returns(person);
            var controller = new PersonController(context.Object);

            controller.ViewData.ModelState.AddModelError("imie", "Podaj imię");
            var result = (ViewResult)controller.Edit(person);
            Assert.AreEqual("Edit", result.ViewName);
        }   
    }
}
