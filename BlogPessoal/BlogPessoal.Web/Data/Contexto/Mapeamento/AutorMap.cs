using BlogPessoal.Web.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogPessoal.Web.Data.Contexto.Mapeamento
{
    public class AutorMap : EntityTypeConfiguration<Autor>
    {
        public AutorMap()
        {
            ToTable("autor", "dbo");
            HasKey(x => x.Id);

            //Só vai ter HasColumnName se o nome do campo no banco for diferente do nome da propriedade da Classe. Não é case-sensitive!
            Property(x => x.Nome).IsRequired().HasMaxLength(150);   //NÃO TEM .HasColumnName("nome")
            Property(x => x.Email).IsRequired().HasMaxLength(150);   //NÃO TEM .HasColumnName("email")
            Property(x => x.Senha).IsRequired().HasMaxLength(50);   //NÃO TEM .HasColumnName("senha")
            Property(x => x.Administrador).IsRequired();   //NÃO TEM .HasColumnName("administrador")
            Property(x => x.DataDeCadastro).IsRequired().HasColumnName("data_cadastro");
        }
    }
}