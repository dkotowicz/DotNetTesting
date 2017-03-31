using MVC_ASP.Models;
using MVC_ASP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ASP.Controllers
{
    [HandleError(View = "Error")]
    [ValueReporter]
    public class PersonController : Controller
    {
        private IPersonSharingContext context;

        public PersonController()
        {
            context = new PersonSharingContext();
        }

        public PersonController(IPersonSharingContext Context)
        {
            context = Context;
        }
        [HandleError(View = "Error")]
        [ValueReporter]
        public ActionResult All()
        {
            List<Person> personAll = context.Persons.ToList();
            return View(personAll);
        }

        [HandleError(ExceptionType = typeof(Exception), View = "ErrorId")]
        public ActionResult DisplayById(int id)
        {
            Person person = context.FindPersonById(id);
            if(person == null)
            {
                throw new Exception();
            }
        
            return View("Display", person);
        }

        public ActionResult Add()
        {
            ViewBag.Napis = "Dodawanie nowej osoby";
            return View("Add");
        }

        [HttpPost]
        public ActionResult Add(PersonAdres personAdres)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", personAdres);
            }
            else
            {
                Adres newAdres = new Adres();
                newAdres.kodPocztowy = personAdres.kodPocztowy;
                newAdres.miasto = personAdres.miasto;
                newAdres.nrBloku = personAdres.nrBloku;
                newAdres.nrMieszkania = personAdres.nrMieszkania;
                newAdres.ulica = personAdres.ulica;
                newAdres.adresId = 10;
                context.Add<Adres>(newAdres);

                Person newPerson = new Person();
                newPerson.adresId = newAdres.adresId;
                newPerson.imie = personAdres.imie;
                newPerson.nazwisko = personAdres.nazwisko;
                newPerson.pesel = personAdres.pesel;
                context.Add<Person>(newPerson);
                context.SaveChanges();
                return RedirectToAction("All", "Person");
            }
        }

        public ActionResult Delete(int id)
        {
            Person person = context.FindPersonById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View("Delete", person);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = context.FindPersonById(id);
            context.Delete<Person>(person);
            context.SaveChanges();
            return RedirectToAction("All", "Person");
        }

        public ActionResult DisplayByPeselNull()
        {
            List<Person> personByPeselNull = context.PersonOfPeselNull().ToList();
            return View("All", personByPeselNull);
        }

        public ActionResult Edit(int id)
        {
            Person person = context.FindPersonById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View("Edit", person);
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", person);
            }
            else
            {
                Person editPerson = context.FindPersonById(person.personId);
                editPerson.imie = person.imie;
                editPerson.nazwisko = person.nazwisko;
                editPerson.pesel = person.pesel;
                context.SaveChanges();
                return RedirectToAction("All", "Person");
            }
        }
    }
}