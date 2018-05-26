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

      /*  [HttpPost]
        [ValidateAntiForgeryToken] //a partir que carrega formulário cria token de validação e se foi mesmo criado do servidor, contra invasores.
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Usuarios.Add(usuario);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  //retorna erro http diferente, requisição mau feita.
            }

            MeuContexto contexto = new MeuContexto();
            Usuario user = contexto.Usuarios.Find(id);

            if (id == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  //retorna erro http diferente, requisição mau feita.
            }

            MeuContexto contexto = new MeuContexto();
            Usuario user = contexto.Usuarios.Find(id);

            if (id == null)
            {
                return HttpNotFound();
            }


            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usu)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Entry(usu).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usu);
        }

      //  public ActionResult Delete(int? id)
       // {
        //    if (id == null)
        //    {
          //      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  //retorna erro http diferente, requisição mau feita.
          //  }

          //  MeuContexto contexto = new MeuContexto();
         //   Usuario user = contexto.Usuarios.Find(id);

          //  if (id == null)
          //  {
          //      return HttpNotFound();
          //  }


        //    return View(user);
       // }

       // [HttpPost, ActionName("Delete")] //esse método é chamado quando chama o delete do Post
       // [ValidateAntiForgeryToken]
      //  public ActionResult DeleteConfirmed(int id)
      //  {
            MeuContexto contexto = new MeuContexto();
           // Usuario usu = contexto.Usuarios.Find(id);
           // contexto.Usuarios.Remove(usu);
          //  contexto.SaveChanges();
          //  return RedirectToAction("Index");
      //  }

    */
    }
}