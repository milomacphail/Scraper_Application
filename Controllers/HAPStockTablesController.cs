using System;
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
    public class HAPStockTablesController : Controller
    {
        private HAPStockTableEntities db = new HAPStockTableEntities();

        // GET: HAPStockTables
        public ActionResult Index()
        {
            return View(db.HAPStockTables.ToList());
        }

        // GET: HAPStockTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAPStockTable hAPStockTable = db.HAPStockTables.Find(id);
            if (hAPStockTable == null)
            {
                return HttpNotFound();
            }
            return View(hAPStockTable);
        }

        // GET: HAPStockTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HAPStockTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Time_Scraped,Stock_Symbol,Last_Price,Change,Change_Percent")] HAPStockTable hAPStockTable)
        {
            if (ModelState.IsValid)
            {
                db.HAPStockTables.Add(hAPStockTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hAPStockTable);
        }

        // GET: HAPStockTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAPStockTable hAPStockTable = db.HAPStockTables.Find(id);
            if (hAPStockTable == null)
            {
                return HttpNotFound();
            }
            return View(hAPStockTable);
        }

        // POST: HAPStockTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Time_Scraped,Stock_Symbol,Last_Price,Change,Change_Percent")] HAPStockTable hAPStockTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hAPStockTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hAPStockTable);
        }

        // GET: HAPStockTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAPStockTable hAPStockTable = db.HAPStockTables.Find(id);
            if (hAPStockTable == null)
            {
                return HttpNotFound();
            }
            return View(hAPStockTable);
        }

        // POST: HAPStockTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HAPStockTable hAPStockTable = db.HAPStockTables.Find(id);
            db.HAPStockTables.Remove(hAPStockTable);
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
