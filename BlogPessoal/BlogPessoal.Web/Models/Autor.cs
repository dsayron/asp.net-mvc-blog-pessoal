using System;
using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.Web.Models
{
    public class Autor
    {
        public Guid Id { get; set; }
        
        [Required]
        public String Nome { get; set; }

        [Required] 
        public String Email { get; set; }

        [Required] 
        public String Senha { get; set; }

        [Required] 
        public Boolean Administrador { get; set; }

        [Required] 
        public DateTime DataDeCadastro { get; set; }

    }
}