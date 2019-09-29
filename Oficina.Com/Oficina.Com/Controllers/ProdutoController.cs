using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oficina.Com.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult ConsultarProduto()
        {
            return View();
        }
    }
}