using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.Web.Models
{
    public class CategoriaDeArtigo
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Nome da Categoria")]
        public string Nome { get; set; }


        [Display(Name = "Descrição da Categoria")]
        [DataType(DataType.MultilineText)]
        [StringLength(300, MinimumLength = 3)]
        public string Descricao { get; set; }

        public virtual ICollection<CategoriaDeArtigo> Artigos { get; set; }

    }

}