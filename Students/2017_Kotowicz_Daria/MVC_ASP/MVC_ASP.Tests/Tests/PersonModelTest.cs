using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_ASP.Models;
using MVC_ASP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ASP.Tests.Tests
{
    [TestClass]
    public class PersonModelTest
    {
        [TestMethod]
        public void CorrectPersonModel()
        {
            var imie = new Person()
            {
                imie = "Kasia",
                nazwisko = "Kowalska",
                pesel = "76456756789"
            };
            var result = TestModelHelper.Validate(imie);
            Assert.AreEqual(0, result.Count);
        }
        [TestMethod]
        public void ImieNullPersonModel()
        {
            var imie = new Person()
            {
                nazwisko = "Kowalska",
                pesel = "76456756789"
            };
            var result = TestModelHelper.Validate(imie);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Podaj imię", result[0].ErrorMessage);
        }
        [TestMethod]
        public void NazwiskoNullPersonModel()
        {
            var imie = new Person()
            {
                imie = "Kasia",
                pesel = "76456756789"
            };
            var result = TestModelHelper.Validate(imie);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Podaj nazwisko", result[0].ErrorMessage);
        }

        [TestMethod]
        public void ImieKrotkiePersonModel()
        {
            var imie = new Person()
            {
                imie = "K",
                nazwisko = "Kowalska",
                pesel = "76456756789"
            };
            var result = TestModelHelper.Validate(imie);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Podane imię jest za krótkie", result[0].ErrorMessage);
        }
        [TestMethod]
        public void NazwiskoKrotkiePersonModel()
        {
            var imie = new Person()
            {
                imie = "Kasia",
                nazwisko = "K",
                pesel = "76456756789"
            };
            var result = TestModelHelper.Validate(imie);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Podane nazwisko jest za krótkie", result[0].ErrorMessage);
        }

        [TestMethod]
        public void imieZnakiPersonModel()
        {
            var imie = new Person()
            {
                imie = "Kasia@",
                nazwisko = "Kowalska",
                pesel = "76456756789"
            };
            var result = TestModelHelper.Validate(imie);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Podałeś złe imię", result[0].ErrorMessage);
        }

        [TestMethod]
        public void nazwiskoZnakiPersonModel()
        {
            var imie = new Person()
            {
                imie = "Kasia",
                nazwisko = "Kowalska@",
                pesel = "76456756789"
            };
            var result = TestModelHelper.Validate(imie);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Podałeś złe nazwisko", result[0].ErrorMessage);
        }

        [TestMethod]
        public void PeselDlugośćPersonModel()
        {
            var imie = new Person()
            {
                imie = "Kasia",
                nazwisko = "Kowalska",
                pesel = "764567567"
            };
            var result = TestModelHelper.Validate(imie);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Podałeś zły pesel", result[0].ErrorMessage);
        }

        [TestMethod]
        public void peselZnakiPersonModel()
        {
            var imie = new Person()
            {
                imie = "Kasia",
                nazwisko = "Kowalska",
                pesel = "764d6756789"
            };
            var result = TestModelHelper.Validate(imie);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Podałeś zły pesel", result[0].ErrorMessage);
        }
    }
}
