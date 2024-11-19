using System;
using System.Linq;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Insuree/Index
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                // Start with a base quote
                decimal quote = 50;

                // Add based on age
                var age = DateTime.Now.Year - insuree.DateOfBirth.Year;
                if (age <= 18)
                {
                    quote += 100; // If 18 or under
                }
                else if (age >= 19 && age <= 25)
                {
                    quote += 50; // If between 19 and 25
                }
                else
                {
                    quote += 25; // If 26 or older
                }

                // Add based on car year
                if (insuree.CarYear < 2000)
                {
                    quote += 25; // If car year is before 2000
                }
                else if (insuree.CarYear > 2015)
                {
                    quote += 25; // If car year is after 2015
                }

                // Add based on car make
                if (insuree.CarMake == "Porsche")
                {
                    quote += 25; // If car make is Porsche
                    if (insuree.CarModel == "911 Carrera")
                    {
                        quote += 25; // Additional for Porsche 911 Carrera
                    }
                }

                // Add for speeding tickets
                quote += insuree.SpeedingTickets * 10; // $10 per speeding ticket

                // Add for DUI
                if (insuree.DUI)
                {
                    quote *= 1.25m; // 25% more for DUI
                }

                // Add for coverage type
                if (insuree.CoverageType)
                {
                    quote *= 1.50m; // 50% more for full coverage
                }

                // Set the calculated quote
                insuree.Quote = quote;

                // Save the record in the database
                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // If model is invalid, return the same view with validation errors
            return View(insuree);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Insuree/Admin
        public ActionResult Admin()
        {
            var allInsurees = db.Insurees.ToList();
            return View(allInsurees);
        }
    }
}
