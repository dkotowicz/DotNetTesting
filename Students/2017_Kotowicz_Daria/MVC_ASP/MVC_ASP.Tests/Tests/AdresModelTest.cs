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
    public class AdresModelTest
    {
        [TestMethod]
        public void CorrecAdresModel()
        {
            var adres = new Adres()
            {
                miasto = "Warszawa",
                ulica = "Słowackiego",
                nrBloku = "41D",
                nrMieszkania = "56",
                kodPocztowy = "90-209"
            };
            var result = TestModelHelper.Validate(adres);
            Assert.AreEqual(0, result.Count);
        }
        [TestMethod]
        public void MiastoKrotkieAdresModel()
        {
            var adres = new Adres()
            {
                miasto = "W",
            };
            var result = TestModelHelper.Validate(adres);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Podana nazwa jest za krótka", result[0].ErrorMessage);
        }
        [TestMethod]
        public void MiastoZnakiAdresModel()
        {
            var adres = new Adres()
            {
                miasto = "Warszawa@",
            };
            var result = TestModelHelper.Validate(adres);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Podałeś złe miasto", result[0].ErrorMessage);
        }

        [TestMethod]
        public void UlicaKrotkieAdresModel()
        {
            var adres = new Adres()
            {
                ulica = "S",

            };
            var result = TestModelHelper.Validate(adres);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Podana nazwa jest za krótka", result[0].ErrorMessage);
        }
        [TestMethod]
        public void UlicaZnakiAdresModel()
        {
            var adres = new Adres()
            {
                ulica = "Słowackiego@",

            };
            var result = TestModelHelper.Validate(adres);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Podałeś złą ulicę", result[0].ErrorMessage);
        }
        [TestMethod]
        public void KodPocztowyDlugoscAdresModel()
        {
            var adres = new Adres()
            {
                kodPocztowy = "80",

            };
            var result = TestModelHelper.Validate(adres);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Podałeś zły kod pocztowy", result[0].ErrorMessage);
        }

        [TestMethod]
        public void KodPocztowyRegexAdresModel()
        {
            var adres = new Adres()
            {
                kodPocztowy = "80+802",

            };
            var result = TestModelHelper.Validate(adres);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Podałeś zły kod pocztowy", result[0].ErrorMessage);
        }

        [TestMethod]
        public void NrBlokuDlugoscAdresModel()
        {
            var adres = new Adres()
            {
                nrBloku = "8067ght",

            };
            var result = TestModelHelper.Validate(adres);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Podałeś zły nr bloku", result[0].ErrorMessage);
        }
        [TestMethod]
        public void NrMieszkaniaZnakiAdresModel()
        {
            var adres = new Adres()
            {
                nrMieszkania = "80D",

            };
            var result = TestModelHelper.Validate(adres);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Podałeś zły nr mieszkania", result[0].ErrorMessage);
        }
    }
}
