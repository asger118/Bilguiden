using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bilguiden.dk.Models;

namespace Bilguiden.dk.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult Biler() { //View med alle biler fra databasen

            List<Biler> AlleBiler = new List<Biler>();

            return View();
        }

        public ActionResult TilføjBil() {   //Tilføj bil til database view
            return View();
        }
        [HttpPost]
        public ActionResult TilføjBil(TilføjBilModel NyBil) {
            Biler Bil = new Biler();
                Bil.Acceleration    = NyBil.Acceleration;
                Bil.Drivmiddel      = NyBil.Drivmiddel;
                Bil.Gearkasse       = NyBil.Gearkasse;
                Bil.Hestekræfter    = NyBil.Hestekræfter;
                Bil.Kubik           = NyBil.Kubik;
                Bil.Lastevne        = NyBil.Lastevne;
                Bil.Model           = NyBil.Model;
                Bil.Motor           = NyBil.Motor;
                Bil.Mærke           = NyBil.Mærke;
                Bil.Newtonmeter     = NyBil.Newtonmeter;
                Bil.Nypris          = NyBil.Nypris;
                Bil.Træk            = NyBil.Træk;
                Bil.Vægt            = NyBil.Vægt;
                Bil.Årgang          = NyBil.Årgang;

            using(bilguidenDBEntities x = new bilguidenDBEntities()) {
                x.Biler.Add(Bil);
                x.SaveChanges();
            }

            ViewBag.SavedData = true;
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}