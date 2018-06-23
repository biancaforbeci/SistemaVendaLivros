using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Web;

namespace SistemaLivros.Models
{
    public class Livro
    {
        [Key]
        public int LivroID { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Display(Name = "Sinopse")]
        [Required(ErrorMessage = "Descrição é obrigatório", AllowEmptyStrings = false)]
        public string Descricao { get; set; }

        [Display(Name = "Quantidade disponível")]
        [Required(ErrorMessage = "Digite uma quantidade", AllowEmptyStrings = false)]
        public int Qtd { get; set; }

        
        [Required(ErrorMessage = "Digite um preço", AllowEmptyStrings = false)]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Capa do Livro")]
        public string Foto { get; set; }


        [Required(ErrorMessage = "Digite uma editora", AllowEmptyStrings = false)]
        public string Editora { get; set; }

        [Display(Name = "Edição")]
        [Required(ErrorMessage = "Faltou o campo edição", AllowEmptyStrings = false)]
        public int Edicao { get; set; }

        [Display(Name = "Ano de Edição")]
        [Required(ErrorMessage = "Digite um ano de edição", AllowEmptyStrings = false)]
        public int AnoEdicao { get; set; }

        [Required(ErrorMessage = "Digite um autor", AllowEmptyStrings = false)]
        public string Autor { get; set; }

        [Display(Name = "Quantidade de Páginas")]
        [Required(ErrorMessage = "Digite a quantidade de páginas", AllowEmptyStrings = false)]
        public int NumeroPaginas { get; set; }
    }
}