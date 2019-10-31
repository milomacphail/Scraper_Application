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
    public class RestSharpTablesController : Controller
    {
        private RestSharpTableEntities db = new RestSharpTableEntities();

        // GET: RestSharpTables
        public ActionResult Index()
        {
            return View(db.RestSharpTables.ToList());
        }

        // GET: RestSharpTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestSharpTable restSharpTable = db.RestSharpTables.Find(id);
            if (restSharpTable == null)
            {
                return HttpNotFound();
            }
            return View(restSharpTable);
        }

        // GET: RestSharpTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestSharpTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TimeScraped,Symbol,LastPrice,Change,ChangePercent")] RestSharpTable restSharpTable)
        {
            if (ModelState.IsValid)
            {
                db.RestSharpTables.Add(restSharpTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restSharpTable);
        }

        // GET: RestSharpTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestSharpTable restSharpTable = db.RestSharpTables.Find(id);
            if (restSharpTable == null)
            {
                return HttpNotFound();
            }
            return View(restSharpTable);
        }

        // POST: RestSharpTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TimeScraped,Symbol,LastPrice,Change,ChangePercent")] RestSharpTable restSharpTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restSharpTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restSharpTable);
        }

        // GET: RestSharpTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestSharpTable restSharpTable = db.RestSharpTables.Find(id);
            if (restSharpTable == null)
            {
                return HttpNotFound();
            }
            return View(restSharpTable);
        }

        // POST: RestSharpTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestSharpTable restSharpTable = db.RestSharpTables.Find(id);
            db.RestSharpTables.Remove(restSharpTable);
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

        [Authorize]
        public ActionResult NewApiCall()
        {
            ApiCall newScrape = new ApiCall();
            newScrape.RestScrape();

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult DeleteTable()
        {
            string deleteQuery = "DELETE FROM RestSharpTable;" + "DBCC CHECKIDENT (RestSharpTable, RESEED, 0);";

            db.Database.ExecuteSqlCommand(deleteQuery);

            return RedirectToAction("Index");

        }
    }
}
