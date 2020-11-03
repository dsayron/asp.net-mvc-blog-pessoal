using System;
using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.Web.Models
{
    public class Artigo
    {
        public Guid Id { get; set; }

        [Required]
        public String Titulo { get; set; }

        [Required]
        public String Conteudo { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Data inválida!")]
        public DateTime Data_Publicacao { get; set; }

        [Required]
        public Boolean Removido { get; set; }

        [Required]
        public Guid Categoria_Artigo_Id { get; set; }

        [Required]
        public Guid Autor_Id { get; set; }

        public virtual CategoriaDeArtigo CategoriaDeArtigo { get; set; }
        public virtual Autor Autor { get; set; }

    }
}