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
    public class RegisterController : Controller
    {
        DBContext db = new DBContext();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registrarse(FormCollection collection)
        {
            string name = collection[0];
            string email = collection[1];
            string password = collection[2];

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Obtener la clave pública y privada
                string publicKey = rsa.ToXmlString(false); // Clave pública
                string privateKey = rsa.ToXmlString(true); // Clave privada

                byte[] encryptedPassword = Encrypt(password, publicKey);

                db.UsuarioDos.Add(new UsuarioDos() { NombreUsuario = name, Correo = email, Contrasena = encryptedPassword, LlavePrivada = privateKey });

                db.SaveChanges();
            }

            return RedirectToAction("Index", "Login");
        }

        public byte[] Encrypt(string password, string publicKey)
        {

            // Encriptar el mensaje con la clave pública
            byte[] encryptedData;
            using (RSACryptoServiceProvider rsaEncrypt = new RSACryptoServiceProvider())
            {
                rsaEncrypt.FromXmlString(publicKey);
                encryptedData = rsaEncrypt.Encrypt(Encoding.UTF8.GetBytes(password), false);
            }

            return encryptedData;
        }
    }
}
