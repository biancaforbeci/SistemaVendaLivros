using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaLivros.Models
{
    public class Cliente
    {

        [Key, ForeignKey("_Endereco")]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o seu CPF", AllowEmptyStrings = false)]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Informe CPF com 11 dígitos válido !")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe o seu RG", AllowEmptyStrings = false)]
        public string RG { get; set; }

        [Required(ErrorMessage = "Informe o seu email", AllowEmptyStrings = false)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido !")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o seu Telefone", AllowEmptyStrings = false)]
        public string Telefone { get; set; }

        public virtual Endereco _Endereco { get; set; }

        public int EnderecoID { get; set; }


    }
}