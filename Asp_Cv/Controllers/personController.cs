using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asp_Cv.Models;
using Asp_Cv.Repository;
namespace Asp_Cv.Controllers
{
    public class personController : Controller
    {
        //
        // GET: /person/
        PersonRep pr = new PersonRep();
        public ActionResult Index()
        {
            User u = Session["UserP"] as User;
            return View();
        }
        public ActionResult insc() {
            return View();   
        }
        public ActionResult newPerson() {
            string nom=Request.Form["nom"];
            string email = Request.Form["email"];
            string mdp = Request.Form["mdp"];
            int age = int.Parse(Request.Form["age"]);
            pr.newPerson(nom,email,mdp,age);
            return Redirect("http://localhost:31416");
        }
    }
}
