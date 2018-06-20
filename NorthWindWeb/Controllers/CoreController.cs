using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NorthWindWeb.Models;

namespace NorthWindWeb.Controllers
{
    public class CoreController : Controller
    {
        // GET: Core
        public ActionResult Index(Customer m)
        {
            return View(m);
        }
        public ActionResult Menu()
        {
             return View();


        }
    }
}