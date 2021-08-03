using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControloAvenca1.Controllers
{
    public class LoginEntradaController : Controller
    {
        ControloAvenca1.DAL.ControloAvencaContext db = new DAL.ControloAvencaContext();
        // GET: LoginEntrada
        public ActionResult Index(string utilizador, string senha)
        {

            bool encontrado = false;
            var t = db.TLogin.ToList();
            foreach (var item in t)
            {
                if (item.Utilizador == utilizador && item.Senha == senha)
                {
                    encontrado = true;
                    Session["user"] = utilizador;
                    ViewBag.X = utilizador;
                    Session["estado"] = "autenticado";
                    //define qual o tempo útil da sessão quando o utilizador ficar muito tempo sem fazer nada
                    Session.Timeout = 10;

                }
            }

            if (!(string.IsNullOrEmpty(utilizador)))
            {
                if (encontrado)
                {
                    ViewBag.SUCESSO = "O login foi efetuado COM sucesso";
                }
                else
                {
                    ViewBag.SUCESSO = "Login SEM sucesso";
                }

            }





            return View();
        }
    }
}