using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaLivros.Models
{
    public class Endereco
    {

        [Key]
        public int EnderecoID { get; set; }

        [Required(ErrorMessage = "Informe a sua rua", AllowEmptyStrings = false)]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Informe o seu número", AllowEmptyStrings = false)]
        public int Numero { get; set; }


        [Required(ErrorMessage = "Informe o seu bairro", AllowEmptyStrings = false)]
        public string Bairro { get; set; }


        [Required(ErrorMessage = "Informe o seu CEP", AllowEmptyStrings = false)]
        public int CEP { get; set; }

     }
}