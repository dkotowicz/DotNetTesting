using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_ASP.Controllers;
using MVC_ASP.Models;
using MVC_ASP.Tests.Doubles;
using MVC_ASP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC_ASP.Tests.Tests
{
    [TestClass]
    public class PersonControllerTest
    {
        [TestMethod]
        public void ChceckViewNameAdd()
        {
            var context = new FakePersonSharingContext();
            var controller = new PersonController(context);
            var result = controller.Add() as ViewResult;
            Assert.AreEqual("Add", result.ViewName);
        }
        [TestMethod]
        public void ChceckTypeListInAll()
        {
            var context = new FakePersonSharingContext();
            context.Persons = new[] {
                 new Person{ personId = 1, imie = "Kasia", nazwisko = "Kowalska", pesel="675678787", adresId=1 },
                 new Person{  personId = 2, imie = "Basia", nazwisko = "Kowalska", pesel=null, adresId=2 },
                 new Person{  personId = 3, imie = "Masia", nazwisko = "Kowalska", pesel=null, adresId=3 }
            }.AsQueryable();
            var controller = new PersonController(context);
            var result = controller.All() as ViewResult;
            Assert.AreEqual(typeof(List<Person>), result.Model.GetType());
        }

        [TestMethod]
        public void TestDisplayAll()
        {
            var context = new FakePersonSharingContext();
            context.Persons = new[] {
                 new Person{ personId = 1, imie = "Kasia", nazwisko = "Kowalska", pesel="675678787", adresId=1 },
                 new Person{  personId = 2, imie = "Basia", nazwisko = "Kowalska", pesel=null, adresId=2 },
                 new Person{  personId = 3, imie = "Masia", nazwisko = "Kowalska", pesel=null, adresId=3 }

             }.AsQueryable();
            var controller = new PersonController(context);
            var result = controller.All() as ViewResult;
            var modelPersons = (IEnumerable<Person>)result.Model;
            Assert.AreEqual(3, modelPersons.Count());
        }

        [TestMethod]
        public void TestDisplayPersobById()
        {
            var context = new FakePersonSharingContext();
            context.Persons = new[] {
                new Person{ personId = 1, imie = "Kasia", nazwisko = "Kowalska", pesel="56457867", adresId=1 },
                new Person{  personId = 2, imie = "Basia", nazwisko = "Kowalska", pesel="56457867", adresId=2 },
                new Person{  personId = 3, imie = "Masia", nazwisko = "Kowalska", pesel="56457867", adresId=3 }

            }.AsQueryable();
            var controller = new PersonController(context);
            var result = controller.DisplayById(2) as ViewResult;
            var resultPerson = (Person)result.Model;
            Assert.AreEqual("Basia", resultPerson.imie);
        }

        [TestMethod]
        public void ChceckTypeListInAllPersonIfPeselNull()
        {
            var context = new FakePersonSharingContext();
            context.Persons = new[] {
                new Person{ personId = 1, imie = "Kasia", nazwisko = "Kowalska", pesel="56457867", adresId=1 },
                new Person{  personId = 2, imie = "Basia", nazwisko = "Kowalska", pesel=null, adresId=2 },
                new Person{  personId = 3, imie = "Masia", nazwisko = "Kowalska", pesel=null, adresId=3 }

            }.AsQueryable();
            var controller = new PersonController(context);
            var result = controller.DisplayByPeselNull() as ViewResult;
            Assert.AreEqual(typeof(List<Person>), result.Model.GetType());
        }

        [TestMethod]
        public void TestDisplayPersonByPeselNull()
        {
            var context = new FakePersonSharingContext();
            context.Persons = new[] {
                 new Person{ personId = 1, imie = "Kasia", nazwisko = "Kowalska", pesel="675678787", adresId=1 },
                 new Person{  personId = 2, imie = "Basia", nazwisko = "Kowalska", pesel=null, adresId=2 },
                 new Person{  personId = 3, imie = "Masia", nazwisko = "Kowalska", pesel=null, adresId=3 }

             }.AsQueryable();
            var controller = new PersonController(context);
            var result = controller.DisplayByPeselNull() as ViewResult;
            var modelPersons = (IEnumerable<Person>)result.Model;
            Assert.AreEqual(2, modelPersons.Count());
        }

        [TestMethod]
        public void TestDeleteView()
        {
            var context = new FakePersonSharingContext();
            context.Persons = new[] {
                new Person{ personId = 1, imie = "Kasia", nazwisko = "Kowalska", pesel="56457866", adresId=1 },
                new Person{  personId = 2, imie = "Basia", nazwisko = "Kowalska", pesel="56457867", adresId=2 },
                new Person{  personId = 3, imie = "Masia", nazwisko = "Kowalska", pesel="56457868", adresId=3 }

            }.AsQueryable();
            var controller = new PersonController(context);
            var result = controller.Delete(2) as ViewResult;
            var resultPerson = (Person)result.Model;
            Assert.AreEqual("56457867", resultPerson.pesel);
        }


        [TestMethod]
        public void TestDeletePersonIsNotNull()
        {
            var context = new FakePersonSharingContext();
            context.Persons = new[] {
                new Person{ personId = 1, imie = "Kasia", nazwisko = "Kowalska", pesel="56457866", adresId=1 },
                new Person{  personId = 2, imie = "Basia", nazwisko = "Kowalska", pesel="56457867", adresId=2 },
                new Person{  personId = 3, imie = "Masia", nazwisko = "Kowalska", pesel="56457868", adresId=3 }

            }.AsQueryable();
            var controller = new PersonController(context);
            var result = controller.Delete(2) as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ChceckViewBackAdd()
        {
            var context = new FakePersonSharingContext();
            var controller = new PersonController(context);
            var result = controller.Add() as ViewResult;
            Assert.IsTrue(result.ViewBag.Napis == "Dodawanie nowej osoby");
        }

        [TestMethod]
        public void TestEditPersonView()
        {
            var context = new FakePersonSharingContext();
            context.Persons = new[] {
                new Person{ personId = 1, imie = "Kasia", nazwisko = "Kowalska", pesel="56457866", adresId=1 },
                new Person{  personId = 2, imie = "Basia", nazwisko = "Kowalska", pesel="56457867", adresId=2 },
                new Person{  personId = 3, imie = "Masia", nazwisko = "Kowalska", pesel="56457868", adresId=3 }

            }.AsQueryable();
            var controller = new PersonController(context);
            var result = controller.Edit(2);
            ViewResult p = (ViewResult)controller.Edit(2);
            var view = p.ViewName;
            Assert.AreEqual("Edit", view);
        }

        [TestMethod]
        public void TestDeleteHttp()
        {
            var context = new FakePersonSharingContext();
            context.Persons = new[] {
                new Person{ personId = 1, imie = "Kasia", nazwisko = "Kowalska", pesel="56457866", adresId=1 },
                new Person{  personId = 2, imie = "Basia", nazwisko = "Kowalska", pesel="56457867", adresId=2 },
                new Person{  personId = 3, imie = "Masia", nazwisko = "Kowalska", pesel="56457868", adresId=3 }

            }.AsQueryable();
            var controller = new PersonController(context);
            var result = controller.Delete(25);
            Assert.AreEqual(typeof(HttpNotFoundResult), result.GetType());
        }

        [TestMethod]
        public void TestEditHttp()
        {
            var context = new FakePersonSharingContext();
            context.Persons = new[] {
                new Person{ personId = 1, imie = "Kasia", nazwisko = "Kowalska", pesel="56457866", adresId=1 },
                new Person{  personId = 2, imie = "Basia", nazwisko = "Kowalska", pesel="56457867", adresId=2 },
                new Person{  personId = 3, imie = "Masia", nazwisko = "Kowalska", pesel="56457868", adresId=3 }

            }.AsQueryable();
            var controller = new PersonController(context);
            var result = controller.Edit(25);
            Assert.AreEqual(typeof(HttpNotFoundResult), result.GetType());
        }

        [TestMethod]
        public void TestDeleteConf()
        {
            var context = new FakePersonSharingContext();
            context.Persons = new[] {
                new Person{ personId = 1, imie = "Kasia", nazwisko = "Kowalska", pesel="56457866", adresId=1 },
                new Person{  personId = 2, imie = "Basia", nazwisko = "Kowalska", pesel="56457867", adresId=2 },
                new Person{  personId = 3, imie = "Masia", nazwisko = "Kowalska", pesel="56457868", adresId=3 }
            }.AsQueryable();
            var controller = new PersonController(context);
            var result = controller.DeleteConfirmed(2) as RedirectToRouteResult;

            Assert.AreEqual("All", result.RouteValues["Action"]);
            Assert.AreEqual("Person", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestAddConf()
        {
            var context = new FakePersonSharingContext();
            context.Persons = new[] {
                 new Person{ personId = 1, imie = "Kasia", nazwisko = "Kowalska", pesel="56457866", adresId=1 },
                 new Person{  personId = 2, imie = "Basia", nazwisko = "Kowalska", pesel="56457867", adresId=2 },
                 new Person{  personId = 3, imie = "Masia", nazwisko = "Kowalska", pesel="56457868", adresId=3 }

             }.AsQueryable();
            context.Adreses = new[]
            {
                new Adres { adresId = 1, miasto="Gdańsk", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"},
                 new Adres { adresId = 2, miasto="Gdańsk", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"},
                  new Adres { adresId = 3, miasto="Gdańsk", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"}
            }.AsQueryable();
            PersonAdres person = new PersonAdres();

            person.imie = "Kasia";
            person.kodPocztowy = "80-292";
            person.miasto = "Gdańsk";
            person.nazwisko = "Kowalska";
            person.nrBloku = "56";
            person.ulica = "Focha";
            person.nrMieszkania = "6";

            var controller = new PersonController(context);
            var result = controller.Add(person) as RedirectToRouteResult;

            Assert.AreEqual("All", result.RouteValues["Action"]);
            Assert.AreEqual("Person", result.RouteValues["Controller"]);

        }
        [TestMethod]
        public void TestEditPerson()
        {
            var context = new FakePersonSharingContext();
            context.Persons = new[] {
                   new Person{ personId = 1, imie = "Kasia", nazwisko = "Kowalska", pesel="56457866", adresId=1 },
                   new Person{  personId = 2, imie = "Basia", nazwisko = "Kowalska", pesel="56457867", adresId=2 },
                   new Person{  personId = 3, imie = "Masia", nazwisko = "Kowalska", pesel="56457868", adresId=3 }
               }.AsQueryable();
            Person person = new Person();

            person.personId = 1;
            person.imie = "Kasia";
            var controller = new PersonController(context);
            var result = controller.Edit(person) as RedirectToRouteResult;

            Assert.AreEqual("All", result.RouteValues["Action"]);
            Assert.AreEqual("Person", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestAddModelNotValid()
        {
            var context = new FakePersonSharingContext();
            context.Persons = new[] {
                 new Person{ personId = 1, imie = "Kasia", nazwisko = "Kowalska", pesel="56457866", adresId=1 },
                 new Person{  personId = 2, imie = "Basia", nazwisko = "Kowalska", pesel="56457867", adresId=2 },
                 new Person{  personId = 3, imie = "Masia", nazwisko = "Kowalska", pesel="56457868", adresId=3 }

             }.AsQueryable();
            context.Adreses = new[]
            {
                new Adres { adresId = 1, miasto="Gdańsk", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"},
                 new Adres { adresId = 2, miasto="Gdańsk", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"},
                  new Adres { adresId = 3, miasto="Gdańsk", ulica = "Góralska", kodPocztowy="80-292", nrBloku= "54f", nrMieszkania="6"}
            }.AsQueryable();
            PersonAdres person = new PersonAdres();
            person.kodPocztowy = "80-292";
            person.miasto = "Gdańsk";
            person.nazwisko = "Kowalska";
            person.pesel = "6743678908";
            person.nrBloku = "56";
            person.ulica = "Focha";
            person.nrMieszkania = "6";

            var controller = new PersonController(context);
            controller.ViewData.ModelState.AddModelError("imie", "Podaj imię");
            var result = (ViewResult)controller.Add(person);
            Assert.AreEqual("Add", result.ViewName);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestDisplayPersonException()
        {
            var context = new FakePersonSharingContext();
            context.Persons = new[] {
                   new Person{ personId = 1, imie = "Kasia", nazwisko = "Kowalska", pesel="67564567897", adresId=1 },
                   new Person{  personId = 2, imie = "Basia", nazwisko = "Kowalska", pesel="56457867", adresId=2 },
                   new Person{  personId = 3, imie = "Masia", nazwisko = "Kowalska", pesel="56457868", adresId=3 }
               }.AsQueryable();
            Person person = new Person();

            person.personId = 1;
            person.pesel = "7678567897";
            var controller = new PersonController(context);
            var result = controller.DisplayById(25);
            Assert.AreEqual(typeof(Exception), result.GetType());
        }



        [TestMethod]
        public void TestController()
        {
            var context = new FakePersonSharingContext();
            var controller = new PersonController();
        }
        
    }
}
