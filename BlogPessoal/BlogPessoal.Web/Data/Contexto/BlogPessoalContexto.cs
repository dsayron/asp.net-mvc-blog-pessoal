using BlogPessoal.Web.Data.Contexto.Mapeamento;
using BlogPessoal.Web.Models;
using System.Data.Entity;

namespace BlogPessoal.Web.Data.Contexto
{
    public class BlogPessoalContexto : DbContext
        {

        //passar no construtor
        //chamar o construtor do dbcontext, passando o "nome"
        //Perceber que "ele" pede uma string
        public BlogPessoalContexto() : base(typeof(BlogPessoalContexto).Name)
        {

        }
        public DbSet<CategoriaDeArtigo> CategoriasDeArtigo { get; set; }
        
        public DbSet<Artigo> Artigo { get; set; }

        public DbSet<Autor> Autor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Adicionar, na linha abaixo, as classes de mapeamento:
            modelBuilder.Configurations.Add(new CategoriaDeArtigoMap());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ArtigoMap());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AutorMap());
            base.OnModelCreating(modelBuilder);
        }
    }


}