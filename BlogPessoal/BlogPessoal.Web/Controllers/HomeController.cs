using BlogPessoal.Web.Data.Contexto;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BlogPessoal.Web.Controllers
{
    public class HomeController : Controller
    {

        private BlogPessoalContexto db = new BlogPessoalContexto();


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

        public ActionResult CategoriasDeArtigo()
        {
            var lista = db.CategoriasDeArtigo.ToList();
            return PartialView("../Shared/_Categorias", lista);
        }
    }
} 