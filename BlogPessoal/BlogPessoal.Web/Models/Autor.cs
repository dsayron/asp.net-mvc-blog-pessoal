using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.Web.Models
{
    public class Autor
    {
        public Guid Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@({\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "O email informado é inválido.")]
        public String Email { get; set; }

        [Required] 

        [DataType(DataType.Password)]
        public String Senha { get; set; }

        [Required] 
        public Boolean Administrador { get; set; }

        [Required] 
        [Display(Name = "Data de Cadastro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataDeCadastro { get; set; }

        public virtual ICollection<Artigo> Artigos { get; set; }
    }
}