using SistemaLivros.Models;
using SistemaLivros.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistemaLivros.Controllers
{
    public class LivrosController : Controller
    {
        // GET: Livros
        public ActionResult Index()
        {
            MeuContexto contexto = new MeuContexto();
            List<Livro> lista = contexto.Livros.ToList();

            return View(lista);
        }

        public ActionResult Create()
        {
            return View();
        }

      
    }
}