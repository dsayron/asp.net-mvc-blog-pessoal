using BlogPessoal.Web.Data.Contexto;
using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using ActionExecutingContext = System.Web.Mvc.ActionExecutingContext;
using ResultExecutingContext = System.Web.Mvc.ResultExecutingContext;

namespace BlogPessoal.Web.Filtros
{
    public class ExibirArtigosActionFilter : ActionFilterAttribute
    {

        private BlogPessoalContexto db = new BlogPessoalContexto();
        //public Guid CategoriaId { get; set; }

        //Fazendo uma resposta no ActionOnResult
        public override void OnResultExecuting
            (ResultExecutingContext filterContext)
        {   
            var artigos = db.Artigos
                //.Where(t => t.Categoria_Artigo_Id == CategoriaId)
                .OrderByDescending(t =>
                t.Data_Publicacao).Take(3).ToList();

            filterContext.Controller.ViewBag.Artigos = artigos;
            base.OnResultExecuting(filterContext);
        }


        //Vai servir como log, capturando informações da action que está sendo realizada.
        //Isso vai ser executado ANTES de rodar a ActionDetails, lá em CategoriasDeArtigoController.cs
        //Aqui é onde se testa se tem 5 acessos conectados "Adquira o plano XXX..."
        public override void OnActionExecuting
            (ActionExecutingContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            var message = string.Format("{0} controller:{1} action: {2}", "onactionexecuting", controllerName, actionName);

            Debug.WriteLine(message, "Action Filter Log");
            base.OnActionExecuting(filterContext);
        }
    }
}