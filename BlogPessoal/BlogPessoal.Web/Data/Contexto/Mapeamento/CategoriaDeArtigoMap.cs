using BlogPessoal.Web.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogPessoal.Web.Data.Contexto.Mapeamento
{
    public class CategoriaDeArtigoMap : EntityTypeConfiguration<CategoriaDeArtigo>
    {
        public CategoriaDeArtigoMap()
        {
            ToTable("categoria_artigo", "dbo");
            HasKey(t => t.Id); //Primary Key
            Property(x => x.Nome).IsRequired().HasMaxLength(150).HasColumnName("nome");
            Property(x => x.Descricao).IsOptional().HasMaxLength(300).HasColumnName("descricao");
        }
    }
}