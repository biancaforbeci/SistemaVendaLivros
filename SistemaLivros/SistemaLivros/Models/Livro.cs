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

        [Display(Name = "Sinopse")]
        [Required(ErrorMessage = "Descrição é obrigatório", AllowEmptyStrings = false)]
        public string Descricao { get; set; }

        [Display(Name = "Quantidade disponível")]
        [Required(ErrorMessage = "Digite uma quantidade", AllowEmptyStrings = false)]
        public int Qtd { get; set; }

        [Display(Name = "Preço")]
        public Decimal Preco { get; set; }

        [Display(Name = "Capa do Livro")]
        public string Foto { get; set; }

        public string Editora { get; set; }

        [Display(Name = "Edição")]
        public int Edicao { get; set; }

        [Display(Name = "Ano de Edição")]
        public int AnoEdicao { get; set; }

        public string Autor { get; set; }

        [Display(Name = "Quantidade de Páginas")]
        public int NumeroPaginas { get; set; }
    }
}