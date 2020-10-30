using BlogPessoal.Web.Data.Contexto;
using BlogPessoal.Web.Models;
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

			//Ordenar por nome e adicionar a uma lista
			var categorias = _ctx.CategoriasDeArtigo
				.OrderBy(t => t.Nome)
				.ToList();
			return View(categorias);

			//O que foi feito? Passamos o enumerable (acho que var categorias) como modelo, para a View "Index"
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

		public ActionResult Edit(int? id)
		{
			if (id == null) //se id for igual a nulo, 
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  // vamos dar um retorno de um actionresult do tipo: BadRequest

			//foi informado o parâmetro id. Caso seja informado: 
			var categoria = _ctx.CategoriasDeArtigo.Find(id); //Uma outra maneira de pesquisar os registros

			if (categoria == null) //nao encontrou ninguém, retornaremos um outro result: 
				return HttpNotFound();

			return View(categoria); //se retornou, mandar para a view de edit, passando a categoria
		}

		[HttpPost]
		public ActionResult Edit(CategoriaDeArtigo categoria)
		{
			if (ModelState.IsValid) // chegando a categoria, verificar se está tudo válido...
			{
				_ctx.Entry(categoria).State = EntityState.Modified();  // se estiver tudo válido, vamos informar que estamos mudando, é uma atualização, agora...
				_ctx.SaveChanges();       //Vai fazer todo o script necessário para que isso seja feito (o que, as mudanças?)
				return RedirectToAction("Index"); //se deu tudo certo,
			}

			return View(categoria); //se deu algo errado, View, passando a categoria.
		}




	}
}