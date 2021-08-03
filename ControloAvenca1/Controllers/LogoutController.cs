using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControloAvenca1.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty((string)Session["user"]))
            {
                //primeira vez, a sessão não tem nenhum valor
                Session["user"] = "";
            }

            if(Session["user"].ToString() == "")
            {
                //por segurança, limpamos na mesma
                Session["user"] = "";
                Session["estado"] = "";
                ViewBag.ESTADO = 1; //Não estava logado
            }
            else
            {
                Session["user"] = "";
                Session["estado"] = "";
                ViewBag.ESTADO = 2; //Estava logado mas deixa de estar
            }


            return View();
        }
    }
}