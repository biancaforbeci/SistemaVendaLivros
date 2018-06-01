using SistemaLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaLivros.Models.DAL;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace SistemaLivros.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel login)
        {
            
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                var v = contexto.Usuarios.Where(a => a.Email.Equals(login.Email)).FirstOrDefault();

                if (v == null)
                {
                    ModelState.AddModelError("Email", "Esse email ainda não está cadastrado");
                    return View(login);
                }
                Session["emailUsuarioLogado"] = login.Email.ToString();
                Session["cliente"] = contexto.Clientes.Find(login.UserID);
                return RedirectToAction("Index");
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel user)
        {

            MeuContexto contexto = new MeuContexto();
            var v = contexto.Usuarios.Where(a => a.Email.Equals(user.Email)).FirstOrDefault();

            if (v != null)
            {
                ModelState.AddModelError("Email", "Esse email já está cadastrado");
                return View(user);
            }

            if (ModelState.IsValid)
            {
                try
                {
                   // MeuContexto contexto = new MeuContexto();
                    LoginViewModel novo = new LoginViewModel();
                    novo.Email = user.Email.ToString();
                    novo.Password = user.Password.ToString();
                    contexto.Usuarios.Add(novo);
                    contexto.SaveChanges();
                    Session["emailUsuarioLogado"] = user.Email.ToString();
                    Session["cliente"] = (contexto.Clientes.Where(a => a.Email.Equals(user.Email)).FirstOrDefault()).Nome;
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return View(e);
                }
            }

            return View(user);
        }

        public ActionResult Index(LoginViewModel login)
        {
            if(Session["cliente"]!= null)
            {
                User.Identity.GetUserId();
            }
            return View(login);
        }

    }
}