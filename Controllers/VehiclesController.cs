﻿using System;
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
    public class VehiclesController : Controller
    {
        private eProject3Entities db = new eProject3Entities();

        // GET: Vehicles
        public ActionResult Index()
        {
            var vehicles = db.Vehicles.Include(v => v.Brand).Include(v => v.VehicleType);
            return View(vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.VehicleBrandId = new SelectList(db.Brands, "Id", "BrandName");
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "VehicleType1");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VehicleName,VehicleTypeId,VehicleBrandId,YearOfManufacture,Seats,Price,VehicleStatus,CreatedDate,UpdatedDate")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleBrandId = new SelectList(db.Brands, "Id", "BrandName", vehicle.VehicleBrandId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "VehicleType1", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleBrandId = new SelectList(db.Brands, "Id", "BrandName", vehicle.VehicleBrandId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "VehicleType1", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VehicleName,VehicleTypeId,VehicleBrandId,YearOfManufacture,Seats,Price,VehicleStatus,CreatedDate,UpdatedDate")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleBrandId = new SelectList(db.Brands, "Id", "BrandName", vehicle.VehicleBrandId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "VehicleType1", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
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
