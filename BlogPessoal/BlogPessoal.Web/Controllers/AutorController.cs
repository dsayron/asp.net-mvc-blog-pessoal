using BlogPessoal.Web.Data.Contexto;
using BlogPessoal.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BlogPessoal.Web.Controllers
{
    public class AutorController : Controller
    {

        private BlogPessoalContexto _ctx = new BlogPessoalContexto();

        // GET: Autor
        public ActionResult Index()
        {
            //ordenar por nome e adicionar a uma lista
            var autor = _ctx.Autor
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
                _ctx.Autor.Add(autor);
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autor);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            //caso seja informado o id:
            var autor = _ctx.Autor.Find(id);

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

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var autor = _ctx.Autor.Find(id);
            if (autor == null)
                return HttpNotFound();

            return View(autor); //se encontrou, vamos retornar uma view de delete, com as informaçòes do objeto autor.
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var autor = _ctx.Autor.Find(id);
            _ctx.Autor.Remove(autor);
            _ctx.SaveChanges();

            //se tudo der certo, mandaremos o usuáro para index
            return RedirectToAction("Index");
        }
    }
}