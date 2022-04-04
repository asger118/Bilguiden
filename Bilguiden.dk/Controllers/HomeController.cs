using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bilguiden.dk.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Helpers;

namespace Bilguiden.dk.Controllers {
    public class HomeController : Controller {
       
        bilguidenDBEntities db = new bilguidenDBEntities();
        
        public ActionResult Index() {
            return View();
        }


        //Detaljer om bil
        public ActionResult Bildetaljer(int? Bil_ID) {
            
            Biler Bil = db.Biler.Find(Bil_ID);
            return View(Bil);
        }

        public ActionResult Sammenlign() {
            
            return View();
        }
        
        [HttpPost]
        public ActionResult Sammenlign(int [] Biler) {
            List<Biler> johnni = new List<Biler>();
            for (int i = 0; i < Biler.Length; i++) {
                var y = Biler[i];
                johnni.Add(db.Biler.FirstOrDefault(x => x.Bil_ID == y));
                Debug.WriteLine(johnni);
            }
            return Json(johnni);
        }
        

        //Rediger deltajer om bil
        public ActionResult RedigerBil(int? id) {

            Biler bil = db.Biler.Find(id);
            return View(bil);
        }

        //Rediger detaljer om bil
        [HttpPost]
        public ActionResult RedigerBil(Biler bil) {

                db.Entry(bil).State = EntityState.Modified;
                db.SaveChanges();

            ViewBag.SavedData = true;
            return View(bil);
        }

        //Tilføj bil til database
        public ActionResult TilføjBil() {

            return View();
        }

        //Henter data fra model til database
        [HttpPost]
        public ActionResult TilføjBil(Biler NyBil, HttpPostedFileBase image1) {

            if (image1 != null) {   // hvis den ikke er lig med null
                NyBil.Billede = new byte[image1.ContentLength];
                image1.InputStream.Read(NyBil.Billede, 0, image1.ContentLength);
            }

            db.Biler.Add(NyBil);

            try {
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx) {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors) {
                    foreach (var validationError in validationErrors.ValidationErrors) {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                    throw raise;
                }
            }
            ViewBag.SavedData = true;
            return View(NyBil);
        } 


        public ActionResult About() {
                ViewBag.Message = "Your application description page.";

                return View();
            }

        public ActionResult Contact() {
                ViewBag.Message = "Your contact page.";

                return View();
        }
        //the first parameter is the option that we choose and the second parameter will use the textbox value  
        public ActionResult Biler(string option, string search) {

            //if a user choose the radio button option as Subject  
            if (option == "Drivmiddel") {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(db.Biler.Where(x => x.Drivmiddel == search || search == null).ToList());
            }
            else if (option == "Model") {
                return View(db.Biler.Where(x => x.Model == search || search == null).ToList());
            }
            else if (option == "Gearkasse") {
                return View(db.Biler.Where(x => x.Gearkasse == search || search == null).ToList());
            }
            else {
                return View(db.Biler.Where(x => x.Mærke.StartsWith(search) || search == null).ToList());
            }
        }
        
    }
   }
    

