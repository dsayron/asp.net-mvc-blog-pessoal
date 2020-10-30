using System;
using System.Linq;
using BlogPessoal.Web.Data.Contexto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogPessoal.Tests
{
    [TestClass]
    public class CategoriaDeArtigoTest
    {
        [TestMethod]
        public void Consultar_artigo_com_sucesso()
        {
            var ctx = new BlogPessoalContexto();
            
            var obj = ctx.CategoriasDeArtigo.FirstOrDefault();  //o primeiro registro ou nulo.

            Assert.IsNotNull(obj);
            // Assert é uma validação
        }
    }
}
