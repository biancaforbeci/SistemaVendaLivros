using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLivros.Models
{
    public class Livro
    {
        public int LivroID { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Qtd { get; set; }
        public double Preco { get; set; }
        public string Caminho { get; set; }
    }
}