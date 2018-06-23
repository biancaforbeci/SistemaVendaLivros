using Microsoft.AspNet.Identity;
using SistemaLivros.Models;
using SistemaVendaLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistemaVendaLivros.Controllers
{
    public class CarrinhoController : Controller
    {
        // GET: Carrinho
        public ActionResult View(int? id)
        {
            MeuContexto contexto = new MeuContexto();
            Livro livro = contexto.Livros.Find(id);             
            if(Request.IsAuthenticated != true)
            {
                return RedirectToAction("Login","Account");
            }
            string login = User.Identity.GetUserId();
            Cliente cli = contexto.Clientes.Where(c => c.LoginID.Equals(login)).FirstOrDefault();

            if(cli != null)
            {
                Carrinho carrinho = new Carrinho();
                carrinho.ClienteID = cli.ClienteID;
                carrinho.LivroID = livro.LivroID;
                carrinho.DiaCompra = DateTime.Now;
                Session["Cliente"] = cli;
                contexto.Carrinho.Add(carrinho);
                contexto.SaveChanges();
                return RedirectToAction("ListCompras");
            }
            else
            {
                ViewBag.Mensagem = "Cliente não cadastrado";
                Session["Cliente"] = null;               
            }
           
            return View();
        }

        public ActionResult ListCompras()
        {
            MeuContexto contexto = new MeuContexto();
            string login = User.Identity.GetUserId().ToString();
            Cliente cli = contexto.Clientes.Where(c => c.LoginID.Equals(login)).FirstOrDefault();

            if(cli != null)
            {
                List<Carrinho> lista = contexto.Carrinho.Include("_Livro").Include("_Cliente").Where(c => c.ClienteID.Equals(cli.ClienteID)).ToList();
               Session["Cliente"] = cli;
               return View(lista);
            }
            else
            {
                ViewBag.Mensagem = "Cliente não cadastrado";
                Session["Cliente"] = null;
                return RedirectToAction("View");
            }            
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  //retorna erro http diferente, requisição mau feita.
            }

            MeuContexto contexto = new MeuContexto();
            List<Carrinho> lista = contexto.Carrinho.Include("_Livro").Include("_Cliente").Where(c => c.CarrinhoID  == id).ToList();

            if (lista.Count == 0)
            {
                return HttpNotFound();
            }

            return View(lista);            
        }

    }
}