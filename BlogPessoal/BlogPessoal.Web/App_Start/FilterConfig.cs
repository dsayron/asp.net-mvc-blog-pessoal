using BlogPessoal.Web.Filtros;
using System.Web.Mvc;

namespace BlogPessoal.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ExibirArtigosActionFilter());
        }
    }
}
