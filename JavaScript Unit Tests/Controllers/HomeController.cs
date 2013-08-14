using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Foolproof.UnitTests.JavaScript.Models;

namespace Foolproof.UnitTests.JavaScript.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new Model());
        }
    }
}
