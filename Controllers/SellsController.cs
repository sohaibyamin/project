using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventory_Managment_System.Models;

namespace Inventory_Managment_System.Controllers
{
    public class SellsController : Controller
    {
        private InventoryMSEntities db = new InventoryMSEntities();

        // GET: Sells
        public ActionResult Index()
        {
            return View(db.Sells.ToList());
        }

        // GET: Sells/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sell sell = db.Sells.Find(id);
            if (sell == null)
            {
                return HttpNotFound();
            }
            return View(sell);
        }

        // GET: Sells/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SellId,CustomerName,ProductId,Quantity,Total,Date")] Sell sell)
        {
            if (ModelState.IsValid)
            {
                db.Sells.Add(sell);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sell);
        }

        // GET: Sells/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sell sell = db.Sells.Find(id);
            if (sell == null)
            {
                return HttpNotFound();
            }
            return View(sell);
        }

        // POST: Sells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SellId,CustomerName,ProductId,Quantity,Total,Date")] Sell sell)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sell).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sell);
        }

        // GET: Sells/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sell sell = db.Sells.Find(id);
            if (sell == null)
            {
                return HttpNotFound();
            }
            return View(sell);
        }

        // POST: Sells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sell sell = db.Sells.Find(id);
            db.Sells.Remove(sell);
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
