using BlogPessoal.Web.Data.Contexto;
using BlogPessoal.Web.Filtros;
using BlogPessoal.Web.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BlogPessoal.Web.Controllers
{
    public class CategoriasDeArtigoController : Controller
	{
		private BlogPessoalContexto _ctx = new BlogPessoalContexto();


        public ActionResult Index()
        {
            //_ctx.Database.Connection.Database
            
            //ordenar por nome e adicionar a uma lista
            var categoria = _ctx.CategoriasDeArtigo
                .OrderBy(t => t.Nome)
                .ToList();
            return View(categoria);
            //passamos o enumerable como modelo, para a view "Index"
        }
        

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoriaDeArtigo categoria)
        {
            if (ModelState.IsValid)
            {
                _ctx.CategoriasDeArtigo.Add(categoria);
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            //caso seja informado o id:
            var categoria = _ctx.CategoriasDeArtigo.Find(id);
            if (categoria == null)
                return HttpNotFound();

            return View(categoria); //se retornou, mandar pa a aview de edit, passando o objeto categoria
        }

        [HttpPost]
        public ActionResult Edit(CategoriaDeArtigo categoria)
        {
            if (ModelState.IsValid) //chegando "categoria", verificar se está tudo válido:
            {
                _ctx.Entry(categoria).State = EntityState.Modified; //se estiver tudo válido, vamos informar que estamos mudando. Agora é uma atualização.
                _ctx.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(categoria);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var categoria = _ctx.CategoriasDeArtigo.Find(id);
            if (categoria == null)
                return HttpNotFound();

            return View(categoria); //se encontrou, vamos retornar uma view de delete, com as informaçòes do objeto categoria.
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var categoria = _ctx.CategoriasDeArtigo.Find(id);
            _ctx.CategoriasDeArtigo.Remove(categoria);
            _ctx.SaveChanges();

            //se tudo der certo, mandaremos o usuáro para index
            return RedirectToAction("Index");
        }

        [ExibirArtigosActionFilter]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaDeArtigo categoria = _ctx.CategoriasDeArtigo.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
    }
}