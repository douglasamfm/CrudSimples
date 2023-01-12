using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodap.Controllers
{
    public class HomeController : Controller
    {
        // GET: Hime
        public ActionResult Index()
        {
            return View();
        }
    }
}