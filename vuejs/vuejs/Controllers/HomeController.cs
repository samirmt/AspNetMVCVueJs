using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using vuejs.Models;
using WEBCENTER.Models;

namespace vuejs.Controllers
{
    public class HomeController : Controller
    {
        _Database db = new _Database();
        private static string msg = "";

        public ActionResult Index()
        {
            var usuario = Cookies.Get("usuariologado").ToString();

            if (!string.IsNullOrEmpty(usuario))
            {
                List<UrlBackendMobile> urls = new UrlBackendMobile().PegarTodos(db);
                return View(urls);
            }
            else
            {
                msg = "Faça o login novamente!";
                return RedirectToAction("Login");
            }           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            Login acesso = new Login();
            if (!string.IsNullOrEmpty(msg)) TempData["mensagem-login"] = msg;
            return View(acesso);
        }

        [HttpPost]
        public ActionResult Login(Login acesso)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Login l = new Login().Logar(db, acesso);

                    if (l != null)
                    {
                        Cookies.Set("usuariologado", l.nome);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        msg = "Usuário e(ou) senha inválidos.";
                        return RedirectToAction("Login");
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message.ToString();
                }
            }
            else
            {
                msg = "Preencha todos os campos.";
            }

            return RedirectToAction("Login");
        }

        public ActionResult LogOut()
        {
            Cookies.Delete("usuariologado");
            FormsAuthentication.SignOut();
            Session.Contents.RemoveAll();
            return RedirectToAction("Login");
        }
    }
}