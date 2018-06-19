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
    }
}