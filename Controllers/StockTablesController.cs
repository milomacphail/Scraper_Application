﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Scraper_Application.Models;

namespace Scraper_Application.Controllers
{
    public class StockTablesController : Controller
    {
        private StockTableEntities db = new StockTableEntities();

        // GET: StockTables
        public ActionResult Index()
        {
            return View(db.StockTables.ToList());
        }

        // GET: StockTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTable stockTable = db.StockTables.Find(id);
            if (stockTable == null)
            {
                return HttpNotFound();
            }
            return View(stockTable);
        }

        // GET: StockTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Time_Scraped,Stock_Symbol,Last_Price,Change,Change_Percent,Volume,Shares,Average_Volume,Market_Cap")] StockTable stockTable)
        {
            if (ModelState.IsValid)
            {
                db.StockTables.Add(stockTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stockTable);
        }

        // GET: StockTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTable stockTable = db.StockTables.Find(id);
            if (stockTable == null)
            {
                return HttpNotFound();
            }
            return View(stockTable);
        }

        // POST: StockTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Time_Scraped,Stock_Symbol,Last_Price,Change,Change_Percent,Volume,Shares,Average_Volume,Market_Cap")] StockTable stockTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockTable);
        }

        // GET: StockTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTable stockTable = db.StockTables.Find(id);
            if (stockTable == null)
            {
                return HttpNotFound();
            }
            return View(stockTable);
        }

        // POST: StockTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockTable stockTable = db.StockTables.Find(id);
            db.StockTables.Remove(stockTable);
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
