using SistemaLivros.Models;
using SistemaVendaLivros.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SistemaLivros.Controllers
{
    public class LivrosController : Controller
    {
        // GET: Livros
        public ActionResult Index()
        {
            MeuContexto contexto = new MeuContexto();
            List<Livro> lista = contexto.Livros.ToList();
            ViewBag.MeusLivros = lista;

            return View(lista);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Livro livro, HttpPostedFileBase file)
        {
           

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/fonts/")
                           + file.FileName);
                    livro.Foto = file.FileName;                   
                    MeuContexto contexto = new MeuContexto();
                    contexto.Livros.Add(livro);
                    contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(livro);
        }

        

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  //retorna erro http diferente, requisição mau feita.
            }

            MeuContexto contexto = new MeuContexto();
            Livro livro = contexto.Livros.Find(id);

            if (id == null)
            {
                return HttpNotFound();
            }


            return View(livro);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                MeuContexto contexto = new MeuContexto();
                Livro livro = contexto.Livros.Find(id);
                contexto.Livros.Remove(livro);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  //retorna erro http diferente, requisição mau feita.
            }

            MeuContexto contexto = new MeuContexto();
            Livro livro = contexto.Livros.Find(id);

            if (id == null)
            {
                return HttpNotFound();
            }


            return View(livro);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Livro livro, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/fonts/")
                           + file.FileName);

                    livro.Foto = file.FileName;
                    MeuContexto contexto = new MeuContexto();
                    contexto.Entry(livro).State = System.Data.Entity.EntityState.Modified;
                    contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(livro);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  //retorna erro http diferente, requisição mau feita.
            }

            MeuContexto contexto = new MeuContexto();
            Livro user = contexto.Livros.Find(id);

            if (id == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        public ActionResult BuscaPorNome()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscaPorNome(string nome)
        {
            MeuContexto contexto = new MeuContexto();
            var serie = contexto.Livros.Where(c => c.Nome.ToLower().Equals(nome.ToLower()));
            List<Livro> lista = serie.ToList();
            ViewBag.Lista = lista;
            if (lista.Count > 0)
            {
                Session["lista"] = serie;
            }else
            {
                Session["lista"] = null;
                ViewBag.Message = "Nada encontrado no sistema para : " + nome;
            }

            return View();
        }

        public ActionResult BuscaPorAutor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscaPorAutor(string nome)
        {
            MeuContexto contexto = new MeuContexto();
            var serie = contexto.Livros.Where(c => c.Autor.ToLower().Equals(nome.ToLower()));
            List<Livro> lista = serie.ToList();
            ViewBag.Lista = lista;
            if (lista.Count > 0)
            {
                Session["lista"] = serie;
            }else
            {
                Session["lista"] = null;
                ViewBag.Message = "Nada encontrado no sistema para : " + nome ;
            }

            return View();
        }

    }
}