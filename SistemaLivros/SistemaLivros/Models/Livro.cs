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


        [Required(ErrorMessage = "Descrição é obrigatório", AllowEmptyStrings = false)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Digite uma quantidade", AllowEmptyStrings = false)]
        public int Qtd { get; set; }

        
        public Decimal Preco { get; set; }
        
        public string Foto { get; set; }

        public string Editora { get; set; }

        public int Edicao { get; set; }

        public int AnoEdicao { get; set; }

        public string Autor { get; set; }

        public int NumeroPaginas { get; set; }
    }
}