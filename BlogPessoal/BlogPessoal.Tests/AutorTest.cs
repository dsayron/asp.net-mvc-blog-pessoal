using BlogPessoal.Web.Data.Contexto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BlogPessoal.Tests
{
    [TestClass]
    public class AutorTest
    {
        [TestMethod]
        public void consultar_autor_com_sucesso()
        {
            var ctx = new BlogPessoalContexto();
            var obj = ctx.Autor.FirstOrDefault(); //o primeiro registro ou nulo

            Assert.IsNull(obj);
            //assert é uma validação
        }
    }
}
