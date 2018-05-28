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

        [Required(ErrorMessage = "Digite um preço", AllowEmptyStrings = false)]
        [Range(10, 99999.99,ErrorMessage = "O Preço de Venda deve estar entre " + "10,00 e 99999,99.")]
        public Decimal Preco { get; set; }

        [Required(ErrorMessage = "Coloque uma imagem !", AllowEmptyStrings = false)]
        public string Caminho { get; set; }
    }
}