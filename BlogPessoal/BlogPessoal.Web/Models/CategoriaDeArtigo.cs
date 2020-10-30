using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogPessoal.Web.Models
{
    public class CategoriaDeArtigo
    {

        public int Id { get; set; }
        
        [Required]
        public String Nome { get; set; }
        public String Descricao { get; set; }


    }
}