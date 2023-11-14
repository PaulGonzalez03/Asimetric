using LoginAsimetricoSi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using static LoginAsimetricoSi.Models.UsuarioDos;

namespace LoginAsimetricoSi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private DBContext db = new DBContext();

        public ActionResult Index()
        {
            if (Session["SesionIniciada"] != null)
            {
                if ((bool)Session["SesionIniciada"] == false)
                {
                    ViewBag.Error = "Error de usuario y/o contraseña";
                }
            }

            return View();
        }
        public ActionResult IniciarSesion(FormCollection collection)
        {
            var email = collection[0];
            var password = collection[1];

            UsuarioDos user = db.UsuarioDos.Where(x => x.Correo == email).FirstOrDefault();

            if (user != null)
            {

                // Desencriptar el mensaje con la clave pública
                byte[] decryptedData;
                using (RSACryptoServiceProvider rsaDecrypt = new RSACryptoServiceProvider())
                {
                    rsaDecrypt.FromXmlString(user.LlavePrivada);
                    decryptedData = rsaDecrypt.Decrypt(user.Contrasena, false);
                }

                string passwordString = Encoding.UTF8.GetString(decryptedData);

                if (password == passwordString)
                {
                    Session["SesionIniciada"] = true;
                    Session["nombre"] = user.NombreUsuario;
                    return RedirectToAction("Index", "Home");
                }
            }

            Session["SesionIniciada"] = false;

            return RedirectToAction("Index");
        }
    }
}