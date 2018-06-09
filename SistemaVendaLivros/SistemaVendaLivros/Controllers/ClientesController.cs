using Microsoft.AspNet.Identity;
using SistemaLivros.Models;
using SistemaVendaLivros.Controllers;
using SistemaVendaLivros.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cli)
        {
            string tel = "^(?:(?([0-9]{2}))?[-. ]?)?([0-9]{4})[-. ]?([0-9]{4})$";
            string verifica = "^[0-9]";
            /*

            Validação de telefone é um problema pra todo mundo mas depois de dar uma pesquisada encontrei uma regex boa. Confira abaixo
            ^(?:(?([0-9]{2}))?[-. ]?)?([0-9]{4})[-. ]?([0-9]{4})$
            Ela cobre os seguintes testes:
            (00) 0000 0000
            (00)-0000-0000
            (00).0000.0000
    */
            if (!Regex.IsMatch(cli.RG, verifica))
            {
                ModelState.AddModelError("RG", "Digite apenas números");
                return View(cli);
            }

            if (Regex.IsMatch(cli.Telefone, tel) == false)
            {
                ModelState.AddModelError("Telefone", "Formatado de telefone inválido. Digite como o exemplo: 3245-5698");
                return View(cli);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    MeuContexto contexto = new MeuContexto();
                    cli.LoginID = User.Identity.GetUserId();
                    contexto.Clientes.Add(cli);
                    contexto.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception e)
                {
                    return View(e);
                }
            }

            return View(cli);
        }

        public ActionResult List()
        {
            MeuContexto contexto = new MeuContexto();
            List<Cliente> lista = contexto.Clientes.ToList();

            return View(lista);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  //retorna erro http diferente, requisição mau feita.
            }

            MeuContexto contexto = new MeuContexto();
            Cliente cli = contexto.Clientes.Find(id);

            if (id == null)
            {
                return HttpNotFound();
            }


            return View(cli);
        }


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Cliente cli)
        {

            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                EditEndereco(cli);
                contexto.Entry(cli).State =
                    System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                EditEndereco(cli);
                return RedirectToAction("/List");
            }


            return View(cli);
        }

        public void EditEndereco(Cliente cli)
        {
            MeuContexto contexto = new MeuContexto();
            Endereco end = contexto.Enderecos.Where(c => c.EnderecoID.Equals(cli.EnderecoID)).FirstOrDefault();
            end.Rua = cli._Endereco.Rua;
            end.Numero = cli._Endereco.Numero;
            end.Bairro = cli._Endereco.Bairro;
            end.CEP = cli._Endereco.CEP;
            contexto.Entry(end).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  //retorna erro http diferente, requisição mau feita.
            }

            MeuContexto contexto = new MeuContexto();
            Cliente cli = contexto.Clientes.Find(id);

            if (id == null)
            {
                return HttpNotFound();
            }


            return View(cli);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                MeuContexto contexto = new MeuContexto();
                Cliente cli = contexto.Clientes.Find(id);
                contexto.Clientes.Remove(cli);
                contexto.SaveChanges();
                DeleteEndereco(cli);
                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                return View(e);
            }

        }

        public void DeleteEndereco(Cliente cli)
        {
            MeuContexto contexto = new MeuContexto();
            Endereco serie = contexto.Enderecos.Where(c => c.EnderecoID.Equals(cli.EnderecoID)).FirstOrDefault();
            contexto.Enderecos.Remove(serie);
            contexto.SaveChanges();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  //retorna erro http diferente, requisição mau feita.
            }

            MeuContexto contexto = new MeuContexto();
            Cliente cli = contexto.Clientes.Find(id);

            if (id == null)
            {
                return HttpNotFound();
            }

            return View(cli);
        }
        
        public ActionResult EditCliente()
        {
            if (User.Identity.IsAuthenticated)
            {
                MeuContexto contexto = new MeuContexto();
                Cliente cli = contexto.Clientes.Where(c => c.LoginID.Equals(User.Identity.GetUserId())).FirstOrDefault();
                Edit(cli.ClienteID);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}