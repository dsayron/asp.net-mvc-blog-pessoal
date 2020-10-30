using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogPessoal.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Contact()
        {
            throw new NotImplementedException();
        }

        public ViewResult About()
        {
            throw new NotImplementedException();
        }
    }
}