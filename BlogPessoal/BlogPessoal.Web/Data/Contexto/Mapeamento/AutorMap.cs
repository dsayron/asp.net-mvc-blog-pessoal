using BlogPessoal.Web.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogPessoal.Web.Data.Contexto.Mapeamento
{
    public class AutorMap : EntityTypeConfiguration<Autor>
    {
        public AutorMap()
        {
            ToTable("autor", "dbo");
            HasKey(t => t.Id);
            Property(x => x.Nome).IsRequired().HasMaxLength(150).HasColumnName("nome");
            Property(x => x.Email).IsRequired().HasMaxLength(150).HasColumnName("email");
            Property(x => x.Senha).IsRequired().HasMaxLength(50).HasColumnName("senha");
            Property(x => x.Administrador).IsRequired().HasColumnName("administrador");
            Property(x => x.DataDeCadastro).IsRequired().HasColumnName("data_cadastro");
        }
    }
}