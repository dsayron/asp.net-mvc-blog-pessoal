using BlogPessoal.Web.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogPessoal.Web.Data.Contexto.Mapeamento
{
    public class ArtigoMap : EntityTypeConfiguration<Artigo> 
    {
        public ArtigoMap()
        {
            ToTable("artigo", "dbo");
            HasKey(t => t.Id);
            Property(x => x.Titulo).IsRequired().HasMaxLength(300).HasColumnName("titulo");
            Property(x => x.Conteudo).IsRequired().HasColumnName("conteudo");
            Property(x => x.Data_Publicacao).IsRequired().HasColumnName("data_publicacao");
            Property(x => x.Categoria_Artigo_Id).IsRequired().HasColumnName("categoria_artigo_id");
            Property(x => x.Autor_Id).IsRequired().HasColumnName("autor_id");
            Property(x => x.Removido).IsRequired().HasColumnName("removido");
        }
    }
}