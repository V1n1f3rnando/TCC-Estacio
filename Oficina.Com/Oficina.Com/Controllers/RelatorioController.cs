using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oficina.Com.Controllers
{
    public class RelatorioController : Controller
    {
        // GET: Relatorio
        public ActionResult Consulta()
        {
            return View();
        }

        public JsonResult Gerar()
        {
            return Json("");
        }
    }
}