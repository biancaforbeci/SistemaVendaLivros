using SistemaLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVendaLivros.Models
{
    public class Carrinho
    {
        public int CarrinhoID { get; set; }
        public int LivroID { get; set; }
        public int ClienteID { get; set; }
        public DateTime DiaCompra { get; set; }
        public Cliente _Cliente { get; set; }
        public Livro _Livro { get; set; }       
    }
}