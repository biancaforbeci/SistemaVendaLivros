using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaLivros.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Visao()
        {
            return View();
        }

        public ActionResult Missao()
        {
            return View();
        }

        public ActionResult Valores()
        {
            return View();
        }

        public ActionResult Contact()
        {
           return View();
        }
    }
}