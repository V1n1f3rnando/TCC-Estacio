using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oficina.Com.Controllers
{
    public class OrdemController : Controller
    {
        // GET: Ordem
        public ActionResult ConsultarOrdem()
        {
            return View();
        }
    }
}