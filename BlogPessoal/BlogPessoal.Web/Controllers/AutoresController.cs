using BlogPessoal.Web.Data.Contexto;
using BlogPessoal.Web.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BlogPessoal.Web.Controllers
{
    public class AutoresController : Controller
    {

        private BlogPessoalContexto _ctx = new BlogPessoalContexto();

        // GET: Autores
        public ActionResult Index()
        {
            //ordenar por nome e adicionar a uma lista
            var autor = _ctx.Autores
                .OrderBy(t => t.Nome)
                .ToList();
            return View(autor);
            //passamos o enumerable como modelo, para a view "Index"
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Autor autor)
        {
            if (ModelState.IsValid)
            {
                _ctx.Autores.Add(autor);
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autor);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            //caso seja informado o id:
            var autor = _ctx.Autores.Find(id);

            if (autor == null)
                return HttpNotFound();

            return View(autor); //se retornou, mandar pa a aview de edit, passando o objeto autor
        }

        [HttpPost]
        public ActionResult Edit(Autor autor)
        {
            if (ModelState.IsValid) //chegando "autor", verificar se está tudo válido:
            {
                _ctx.Entry(autor).State = EntityState.Modified; //se estiver tudo válido, vamos informar que estamos mudando. Agora é uma atualização.
                _ctx.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(autor);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var autor = _ctx.Autores.Find(id);
            if (autor == null)
                return HttpNotFound();

            return View(autor); //se encontrou, vamos retornar uma view de delete, com as informaçòes do objeto autor.
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var autor = _ctx.Autores.Find(id);
            _ctx.Autores.Remove(autor);
            _ctx.SaveChanges();

            //se tudo der certo, mandaremos o usuáro para index
            return RedirectToAction("Index");
        }
    }
}