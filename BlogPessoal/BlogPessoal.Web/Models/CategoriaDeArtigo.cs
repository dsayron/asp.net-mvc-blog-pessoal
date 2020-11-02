using System;
using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.Web.Models
{
    public class CategoriaDeArtigo
    {

        public int Id { get; set; } 
        
        [Required]
        [Display(Name = "Nome da categoria")]
        public String Nome { get; set; }


        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText, ErrorMessage = "Descrição inválida!")]
        [StringLength(300, MinimumLength = 1)] 
        public String Descricao { get; set; }


    }

}