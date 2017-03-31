using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ASP.Controllers
{

    [HandleError(View = "Error")]
    [ValueReporter]
    [HandleError(ExceptionType = typeof(Exception), View = "ErrorPage")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            throw new Exception();
        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            throw new Exception();
        }
     
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            throw new Exception();
        }
    }

    
}