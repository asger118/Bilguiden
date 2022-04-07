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
using System.Collections;

namespace Bilguiden.dk.Controllers {
    public class HomeController : Controller {
        bilguidenDBEntities db = new bilguidenDBEntities();

        //Index side
        public ActionResult Index() { return View(); }


        //Detaljer om bil
        public ActionResult Bildetaljer(int? Bil_ID) {
           
            Biler Bil = db.Biler.Find(Bil_ID);
            return View(Bil);
        }
        
        //Side med biler man sammenligner
        public ActionResult Sammenlign(int Bil_ID1, int Bil_ID2, int? Bil_ID3) {
            //Laver en ny liste af biler og tilføjer de biler man har valgt ud fra deres ID
            List<Biler> cars = new List<Biler>();
            cars.Add(db.Biler.First(x => x.Bil_ID == Bil_ID1));
            cars.Add(db.Biler.First(x => x.Bil_ID == Bil_ID2));
            if( Bil_ID3 != null) { cars.Add(db.Biler.First(x => x.Bil_ID == Bil_ID3)); }
            //Returner viewet med Listen af udvalgte biler
            return View(cars);
        }


        //Rediger deltajer om bil
        public ActionResult RedigerBil(int? id) {

            Biler bil = db.Biler.Find(id);
            return View(bil);
        }


        //Rediger detaljer om bil
        [HttpPost]
        public ActionResult RedigerBil(Biler bil, HttpPostedFileBase image1) {

            db.Entry(bil).State = EntityState.Modified;
            
            if (image1 != null) {
                bil.Billede = new byte[image1.ContentLength];
                image1.InputStream.Read(bil.Billede, 0, image1.ContentLength);
            }

            
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
            return View(bil);
        }

        //Tilføj bil til database
        public ActionResult TilføjBil() {

            return View();
        }

        //Henter data fra model til database
        [HttpPost]
        public ActionResult TilføjBil(Biler NyBil, HttpPostedFileBase image1) {

            if (image1 != null) { 
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

        //Den første parameter er hvad man vil søge efter og anden parameter er hvad man søger
        public ActionResult Biler(string option, string search) {

            //Hvis man søger efter Drivmiddel  
            if (option == "Drivmiddel") {
                //Finder Biler med det drivmiddel man søger efter
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
    

