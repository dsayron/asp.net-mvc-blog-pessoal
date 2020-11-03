using BlogPessoal.Web.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogPessoal.Web.Data.Contexto.Mapeamento
{
    public class ArtigoMap : EntityTypeConfiguration<Artigo> 
    {
        public ArtigoMap()
        {
            ToTable("artigo", "dbo");
            HasKey(X => X.Id); //ESTAVA t => t.Id!
            Property(x => x.Titulo).IsRequired().HasMaxLength(300);   //NÃO TEM .HasColumnName("titulo");
            Property(x => x.Conteudo).IsRequired();   //NÃO TEM .HasColumnName("conteudo");
            Property(x => x.Data_Publicacao).IsRequired();   //NÃO TEM .HasColumnName("data_publicacao");
            Property(x => x.Categoria_Artigo_Id).IsRequired();   //NÃO TEM .HasColumnName("categoria_artigo_id");
            Property(x => x.Autor_Id).IsRequired();   //NÃO TEM .HasColumnName("autor_id");
            Property(x => x.Removido).IsRequired();   //NÃO TEM .HasColumnName("removido");


            //Mapeamento:
            // Em categoria de artigo, pode haver vários (many) artigos
            HasRequired(t => t.CategoriaDeArtigo)
                .WithMany(t => (System.Collections.Generic.ICollection<Artigo>)t.Artigos)
                .HasForeignKey(t => t.Categoria_Artigo_Id)
                .WillCascadeOnDelete(false);


            //Mesma coisa no autor:
            HasRequired(t => t.Autor)
                .WithMany(t => t.Artigos)
                .HasForeignKey(t => t.Autor_Id)
                .WillCascadeOnDelete(false);
        }
    }
}