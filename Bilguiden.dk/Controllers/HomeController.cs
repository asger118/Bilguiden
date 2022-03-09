using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bilguiden.dk.Models;

namespace Bilguiden.dk.Controllers {
    public class HomeController : Controller {
       
        bilguidenDBEntities x = new bilguidenDBEntities();
        
        public ActionResult Index() {
            return View();
        }


        //Tilføj biler til showroom page
        public ActionResult Biler() {
          
            var item = (from d in x.Biler
                        select d).ToList();
            return View(item);
        }

        //Detaljer om bil
        public ActionResult Bildetaljer(int Bil_ID = 0) {
            
            Biler Bil = x.Biler.Find(Bil_ID);
            return View(Bil);
        }

        //Rediger deltajer om bil
        public ActionResult RedigerBil(int Id) {

            Biler bil = x.Biler.Find(Id);
            return View(bil);
        }

        //Rediger detaljer om bil
        [HttpPost]
        public ActionResult RedigerBil(Biler bil, HttpPostedFileBase image1) {

            if (ModelState.IsValid) {
                if (image1 != null) {
                    bil.Billede = new byte[image1.ContentLength];
                    image1.InputStream.Read(bil.Billede, 0, image1.ContentLength);
                }
                try {
                    x.SaveChanges();
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
                x.Entry(bil).State = EntityState.Modified;
                x.SaveChanges();
            }
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

            x.Biler.Add(NyBil);

            try {
                x.SaveChanges();
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
        }
   }
    

