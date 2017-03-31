using MVC_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ASP.Controllers
{
    [HandleError(View = "Error")]
    [ValueReporter]
    public class AdresController : Controller
    {
        private IPersonSharingContext context;

        public AdresController()
        {
            context = new PersonSharingContext();
        }

        public AdresController(IPersonSharingContext Context)
        {
            context = Context;
        }

        [HandleError(ExceptionType = typeof(Exception), View = "ErrorId")]
        public ActionResult DisplayById(int id)
        {
            Adres adres = context.FindAdresById(id);

            if(adres==null){
                throw new Exception();
            }
            return View("Display", adres);
        }

        [HandleError(ExceptionType = typeof(Exception), View = "ErrorId")]
        public ActionResult Edit(int id)
        {
            Adres adres = context.FindAdresById(id);
            if(adres == null)
            {
                throw new Exception();
            }
            return View("Edit", adres);
        }

        [HttpPost]
        public ActionResult Edit(Adres adres)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", adres);
            }
            Adres editAdres = context.FindAdresById(adres.adresId);
            editAdres.kodPocztowy = adres.kodPocztowy;
            editAdres.miasto = adres.miasto;
            editAdres.nrBloku = adres.nrBloku;
            editAdres.nrMieszkania = adres.nrMieszkania;
            editAdres.ulica = adres.ulica;
            context.SaveChanges();
            return RedirectToAction("All", "Person");
        }
    }
}