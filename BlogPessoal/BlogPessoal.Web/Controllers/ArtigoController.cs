using BlogPessoal.Web.Data.Contexto;
using BlogPessoal.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace BlogPessoal.Web.Controllers
{
    public class ArtigoController : Controller
    {

        private BlogPessoalContexto _ctx = new BlogPessoalContexto();

        // GET: Artigo
        public ActionResult Index()
        {
            //ordenar por nome e adicionar a uma lista
            var artigo = _ctx.Artigo
                .OrderBy(t => t.Titulo)
                .ToList();
            return View(artigo);
            // o que foi feito? passamos o enumerable como modelo, para a view "index"
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Artigo artigo)
        {
            if (ModelState.IsValid)
            {
                _ctx.Artigo.Add(artigo);
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artigo);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            //Caso seja informado o parametro id:
            var artigo = _ctx.Artigo.Find(id);
            if (artigo == null)
                return HttpNotFound();

            return View(artigo);
        }

        [HttpPost]
        public ActionResult Edit(Artigo artigo)
        {
            if (ModelState.IsValid) //
            {
                _ctx.Entry(artigo).State = System.Data.Entity.EntityState.Modified; //se tudo válido, informar que estamos mudando.
                _ctx.SaveChanges(); //vai fazer todo o script necessário para que isso seja feito (as mudanças??)
                return RedirectToAction("Index");
            }
            return View(artigo); //se deu algo errado, View, passando a "artigo".
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            var artigo = _ctx.Artigo.Find(id);
            if (artigo == null)
                return HttpNotFound();

            return View(artigo);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var artigo = _ctx.Artigo.Find(id);
            _ctx.Artigo.Remove(artigo);
            _ctx.SaveChanges();

            //Se tudo deu certo, mandaremos o usuario para index:
            return RedirectToAction("Index");
        }
    }
}