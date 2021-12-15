using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eProject3_Verhicle_Management.Models;

namespace eProject3_Verhicle_Management.Controllers
{
    public class CurrencyConversionsController : Controller
    {
        private eProject3Entities db = new eProject3Entities();

        // GET: CurrencyConversions
        public ActionResult Index()
        {
            return View(db.CurrencyConversions.ToList());
        }

        // GET: CurrencyConversions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyConversion currencyConversion = db.CurrencyConversions.Find(id);
            if (currencyConversion == null)
            {
                return HttpNotFound();
            }
            return View(currencyConversion);
        }

        // GET: CurrencyConversions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurrencyConversions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FromCurrency,ToCurrency,Ratio")] CurrencyConversion currencyConversion)
        {
            if (ModelState.IsValid)
            {
                db.CurrencyConversions.Add(currencyConversion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(currencyConversion);
        }

        // GET: CurrencyConversions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyConversion currencyConversion = db.CurrencyConversions.Find(id);
            if (currencyConversion == null)
            {
                return HttpNotFound();
            }
            return View(currencyConversion);
        }

        // POST: CurrencyConversions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FromCurrency,ToCurrency,Ratio")] CurrencyConversion currencyConversion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currencyConversion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(currencyConversion);
        }

        // GET: CurrencyConversions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyConversion currencyConversion = db.CurrencyConversions.Find(id);
            if (currencyConversion == null)
            {
                return HttpNotFound();
            }
            return View(currencyConversion);
        }

        // POST: CurrencyConversions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CurrencyConversion currencyConversion = db.CurrencyConversions.Find(id);
            db.CurrencyConversions.Remove(currencyConversion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
