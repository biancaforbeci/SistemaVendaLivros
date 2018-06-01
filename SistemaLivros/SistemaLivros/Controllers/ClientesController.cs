using SistemaLivros.Models;
using SistemaLivros.Models.DAL;
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

        public void SalvaClienteLogin(Cliente cli)
        {
            MeuContexto contexto = new MeuContexto();
            
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

            if (Regex.IsMatch(cli.Telefone, tel)== false)
            {
                ModelState.AddModelError("Telefone", "Formatado de telefone inválido. Digite como o exemplo: 3245-5698");
                return View(cli);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    MeuContexto contexto = new MeuContexto();
                    contexto.Clientes.Add(cli);
                    contexto.SaveChanges();
                    SalvaClienteLogin(cli);
                    return RedirectToAction("List");
                }catch(Exception e)
                {
                    return View(e);
                }
            }

            return View(cli);
        }
       
        public void EditUser()
        {
            MeuContexto contexto = new MeuContexto();
            
        }

        public ActionResult List()
        {
            MeuContexto contexto = new MeuContexto();
            List<Cliente>lista=contexto.Clientes.ToList();

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
        public ActionResult EditPost(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();
             var clienteToUpdate = contexto.Clientes.Find(id);
            if (ModelState.IsValid)
            {
                 int endID = clienteToUpdate.EnderecoID;
                var endToUpdate = contexto.Enderecos.Find(endID);
                if (TryUpdateModel(clienteToUpdate, "", new string[] { "Nome", "CPF", "RG", "Email", "Telefone" }) &&
                   TryUpdateModel(endToUpdate, "", new string[] { "_Endereco.Rua", "_Endereco.Numero", "_Endereco.Bairro", "_Endereco.CEP" }))
                {
                    try
                    {
                        contexto.SaveChanges();

                        return RedirectToAction("List");
                    }
                    catch (RetryLimitExceededException /* dex */)
                    {
                        //Log the error (uncomment dex variable name and add a line here to write a log.
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    }
                }
            }
            
            return View(clienteToUpdate);
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
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                MeuContexto contexto = new MeuContexto();
                Cliente cli = contexto.Clientes.Find(id);
                Endereco end = (from x in contexto.Enderecos
                                   where x.EnderecoID.Equals(cli.EnderecoID)
                                   select x).FirstOrDefault();
                contexto.Enderecos.Remove(end);
                contexto.Clientes.Remove(cli);                
                contexto.SaveChanges();
                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                return View(e);
            }
            
        }

    }
}