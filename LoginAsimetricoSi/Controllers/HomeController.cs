using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using static LoginAsimetricoSi.Models.UsuarioDos;

namespace LoginAsimetricoSi.Controllers
{
    public class HomeController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult Index()
        {
            if (Session["SesionIniciada"] != null)
            {
                if ((bool)Session["SesionIniciada"] == true) {
                    ViewBag.nombreUsuario = Session["nombre"];
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}