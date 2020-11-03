using BlogPessoal.Web.Data.Contexto;
using BlogPessoal.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BlogPessoal.Web.Controllers
{
    public class ArtigosController : Controller
    {

        private BlogPessoalContexto _ctx = new BlogPessoalContexto();

        // GET: Artigos
        public ActionResult Index()
        {
            //ordenar por nome e adicionar a uma lista
            var artigo = _ctx.Artigos
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
                _ctx.Artigos.Add(artigo);
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artigo);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            //Caso seja informado o parametro id:
            var artigo = _ctx.Artigos.Find(id);
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

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            var artigo = _ctx.Artigos.Find(id);
            if (artigo == null)
                return HttpNotFound();

            return View(artigo);
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var artigo = _ctx.Artigos.Find(id);
            _ctx.Artigos.Remove(artigo);
            _ctx.SaveChanges();

            //Se tudo deu certo, mandaremos o usuario para index:
            return RedirectToAction("Index");
        }
    }
}