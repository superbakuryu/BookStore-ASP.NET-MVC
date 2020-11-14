using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLSach.Models;

namespace QLSach.Controllers
{
    public class tb_NXBController : Controller
    {
        private BookShopEntities db = new BookShopEntities();

        // GET: tb_NXB
        public ActionResult Index()
        {
            return View(db.tb_NXB.ToList());
        }

        // GET: tb_NXB/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NXB tb_NXB = db.tb_NXB.Find(id);
            if (tb_NXB == null)
            {
                return HttpNotFound();
            }
            return View(tb_NXB);
        }

        // GET: tb_NXB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_NXB/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maNXB,tenNXB,diaChi,dienThoai,email")] tb_NXB tb_NXB)
        {
            if (ModelState.IsValid)
            {
                db.tb_NXB.Add(tb_NXB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_NXB);
        }

        // GET: tb_NXB/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NXB tb_NXB = db.tb_NXB.Find(id);
            if (tb_NXB == null)
            {
                return HttpNotFound();
            }
            return View(tb_NXB);
        }

        // POST: tb_NXB/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maNXB,tenNXB,diaChi,dienThoai,email")] tb_NXB tb_NXB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_NXB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_NXB);
        }

        // GET: tb_NXB/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NXB tb_NXB = db.tb_NXB.Find(id);
            if (tb_NXB == null)
            {
                return HttpNotFound();
            }
            return View(tb_NXB);
        }

        // POST: tb_NXB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_NXB tb_NXB = db.tb_NXB.Find(id);
            db.tb_NXB.Remove(tb_NXB);
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
