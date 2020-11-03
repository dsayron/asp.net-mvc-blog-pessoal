using BlogPessoal.Web.Data.Contexto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BlogPessoal.Tests
{
    [TestClass]
    public class ArtigoTest
    {
        [TestMethod]
        public void ConsultarArtigoComSucesso()
        {
            var ctx = new BlogPessoalContexto();
            var obj = ctx.Artigos.FirstOrDefault();  //o primeiro registro ou nulo.

            Assert.IsNotNull(obj);
            // Assert é uma validação
        }
    }
}
