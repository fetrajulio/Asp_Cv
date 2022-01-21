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
        public ActionResult sup(int id) {
            pr.supp(id);
            return Redirect("http://localhost:31416");
        }
        public ActionResult modif(int id) {
            List<Person> all = pr.getAll().ToList();
            Person p = all.Find(x=>x.Id==id);
            ViewBag.pers = p;
            return View();
        }

        public ActionResult exeMod(int id) {
            
            string nom = Request.Form["nom"];
            string email = Request.Form["email"];
            string mdp = Request.Form["mdp"];
            int age = int.Parse(Request.Form["age"]);
            pr.modif(id,nom,email,mdp,age);
            return Redirect("http://localhost:31416");
            
        }
    }
}
