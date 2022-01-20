using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asp_Cv.Models;
namespace Asp_Cv.Controllers
{
    public class personController : Controller
    {
        //
        // GET: /person/

        public ActionResult Index()
        {
            User u = Session["UserP"] as User;
            return View();
        }

    }
}
