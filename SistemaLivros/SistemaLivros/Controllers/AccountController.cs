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
        public static LoginViewModel User;

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
                var v = contexto.Usuarios.Where(a => a.Email.Equals(login.Email) && a.Password.Equals(login.Password)).FirstOrDefault();

                if (v == null)
                {
                    ModelState.AddModelError("Email", "Esse email ainda não está cadastrado");
                    return View(login);
                }
                User = v;
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
            
            return View(login);
        }

    }
}