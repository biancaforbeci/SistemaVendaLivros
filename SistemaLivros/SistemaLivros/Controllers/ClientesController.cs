using SistemaLivros.Models;
using SistemaLivros.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace SistemaLivros.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {                      
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Cliente cli)
        {
            MeuContexto contexto = new MeuContexto();
            var c = (from x in contexto.Clientes
                     where x.Senha.ToLower().Equals(cli.Senha.ToLower()) && x.Email.ToLower().Equals(cli.Email.ToLower())
                     select x);

            if (c == null)
            {
                return HttpNotFound();
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cli)
        {
            string tel = "^(?:(?([0-9]{2}))?[-. ]?)?([0-9]{4})[-. ]?([0-9]{4})$";

            /*

            Validação de telefone é um problema pra todo mundo mas depois de dar uma pesquisada encontrei uma regex boa. Confira abaixo
            ^(?:(?([0-9]{2}))?[-. ]?)?([0-9]{4})[-. ]?([0-9]{4})$
            Ela cobre os seguintes testes:
            (00) 0000 0000
            (00)-0000-0000
            (00).0000.0000
    */
            if (Regex.IsMatch(cli.Telefone, tel)== false)
            {
                ModelState.AddModelError("Telefone", "Formatado de telefone inválido. Digite como o exemplo: 3245-5698");
                return View(cli);
            }

            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Clientes.Add(cli);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cli);
        }

        



    }
}