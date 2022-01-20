using Asp_Cv.Models;
using Asp_Cv.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp_Cv.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        PersonRep PersRep = new PersonRep();
        public ActionResult Index()
        {
            ViewBag.persons = PersRep.getAll();
            return View();
        }

        public ActionResult login() {
            string Email = Request.Form["email"];
            string Mdp = Request.Form["mdp"];

            
            if (PersRep.testLogin(Email, Mdp) != null) {
                Person p = PersRep.testLogin(Email,Mdp);
                var userP = new User(p.Id,p.Nom,p.Email);
                this.Session["UserP"] = userP;
                return Redirect("http://localhost:31416/person");
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult search() {
            string txt=Request.Form["texte"];
            if(txt!="")
                ViewBag.persons = PersRep.get(txt);
            else
                ViewBag.persons = PersRep.getAll();
            return View("Index");
        }
    }
}
