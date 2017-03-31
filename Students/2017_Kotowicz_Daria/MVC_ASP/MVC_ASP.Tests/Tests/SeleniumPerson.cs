using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using System.Collections.ObjectModel;

namespace MVC_ASP.Tests.Tests
{
    [TestClass]
    public class SeleniumPerson
    {
        [TestMethod]
        public void TestClickSprawdzAdres()
        {
            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:9098/Person/All");
            IWebElement element = driver.FindElement(By.Name("sprAdres"));
            element.Click();
            string checkTest = driver.FindElement(By.Id("Title")).Text;
            Assert.AreEqual("Adres osoby", checkTest);
            driver.Close();
        }

        [TestMethod]
        public void TestClickUsun()
        {
            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:9098/Person/All");
            IWebElement element = driver.FindElement(By.Name("usunPerson"));
            element.Click();
            string checkTest = driver.FindElement(By.Id("Title")).Text;
            Assert.AreEqual("Usuwanie osoby", checkTest);
            driver.Close();
        }

        [TestMethod]
        public void TestTextEdytuj()
        {
            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:9098/Person/All");
            IWebElement el = driver.FindElement(By.Name("edytuj"));
            String message = el.Text;
            String successMsg = "Edytuj dane";
            Assert.AreEqual(message, successMsg);
            driver.Close();
        }

        [TestMethod]
        public void TestAddPerson()
        {
            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:9098/Person/Add");
            driver.FindElement(By.Id("nazwisko")).Click();
            driver.FindElement(By.Id("nazwisko")).SendKeys("Nowak");
            driver.FindElement(By.Id("imie")).Click();
            driver.FindElement(By.Id("imie")).SendKeys("Kasia");
            driver.FindElement(By.Name("dodaj")).Click();
            string checkTest = driver.FindElement(By.Name("Title")).Text;
            Assert.AreEqual("Lista wszystkich osób", checkTest);
            driver.Close();
        }

        [TestMethod]
        public void TestAllPerson()
        {
            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:9098/Person/All");

            IWebElement table = driver.FindElement(By.XPath("/html/body/div[2]/table"));

            ReadOnlyCollection<IWebElement> allRows = table.FindElements(By.TagName("tr"));
            int licz = 0;
            foreach (IWebElement row in allRows)
            {
                ReadOnlyCollection<IWebElement> cells = row.FindElements(By.TagName("td"));

                foreach (IWebElement cell in cells)
                {
                    //Console.WriteLine("\t" + cell.Text);
                }
                licz++;
            }
            Assert.IsTrue(licz > 4);
            driver.Close();
        }

    }
}
