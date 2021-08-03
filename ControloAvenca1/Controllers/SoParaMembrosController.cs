using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControloAvenca1.Controllers
{
    public class SoParaMembrosController : Controller
    {
        // GET: SoParaMembros
        public ActionResult Index()
        {
            //string estado;

            //try
            //{
            //    //if (string.IsNullOrEmpty((string)Session["estado"]))
            //    //{
            //    //    estado = (string)Session["estado"].ToString();
            //    //}
            //    estado = (string)Session["estado"].ToString();

            //}
            //catch (Exception)
            //{
            //    estado = "";
            //}

            //if(estado == "autenticado")
            //{
            //return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Error");
            //}

            if (string.IsNullOrEmpty((string)Session["estado"]))
            {
                return RedirectToAction("Index", "Error");
            }
            else
            {
                return View();
            }

    }
    }
}