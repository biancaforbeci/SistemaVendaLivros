using SistemaLivros.Models;
using SistemaLivros.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpPost,ActionName("Delete")]
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

        public ActionResult Busca(object sender, EventArgs e)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Busca(EscolhaLivro value, string opcao)
        {
            
            if (value.EscolhaLivroID ==1 )
            {
                try
                {
                    MeuContexto contexto = new MeuContexto();
                    List<Livro> busca = (from x in contexto.Livros
                                         where x.Autor.Equals(opcao)
                                         select x).ToList();
                    if (busca.Count > 0)
                    {
                        return View();
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
                catch(Exception e)
                {
                    return View(e);
                }                       
            }

            if (value.EscolhaLivroID==2)
            {
                try
                {
                    MeuContexto contexto = new MeuContexto();
                    List<Livro>busca = (from x in contexto.Livros
                                         where x.Nome.Equals(opcao)
                                         select x).ToList();
                   if (busca.Count > 0)
                    {
                        return View();
                    }
                    else
                    {
                        return HttpNotFound();
                    }                    
                    
                }
                catch(Exception e)
                {
                    return View(e);
                }
                
            }

            return (HttpNotFound());
        }

        
        
    }
}