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
    public class tb_GianHangController : Controller
    {
        private BookShopEntities db = new BookShopEntities();

        // GET: tb_GianHang
        public ActionResult Index()
        {
            return View(db.tb_GianHang.ToList());
        }

        // GET: tb_GianHang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_GianHang tb_GianHang = db.tb_GianHang.Find(id);
            if (tb_GianHang == null)
            {
                return HttpNotFound();
            }
            return View(tb_GianHang);
        }

        // GET: tb_GianHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_GianHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maGianHang,tenGianHang,moTa")] tb_GianHang tb_GianHang)
        {
            if (ModelState.IsValid)
            {
                db.tb_GianHang.Add(tb_GianHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_GianHang);
        }

        // GET: tb_GianHang/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_GianHang tb_GianHang = db.tb_GianHang.Find(id);
            if (tb_GianHang == null)
            {
                return HttpNotFound();
            }
            return View(tb_GianHang);
        }

        // POST: tb_GianHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maGianHang,tenGianHang,moTa")] tb_GianHang tb_GianHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_GianHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_GianHang);
        }

        // GET: tb_GianHang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_GianHang tb_GianHang = db.tb_GianHang.Find(id);
            if (tb_GianHang == null)
            {
                return HttpNotFound();
            }
            return View(tb_GianHang);
        }

        // POST: tb_GianHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_GianHang tb_GianHang = db.tb_GianHang.Find(id);
            db.tb_GianHang.Remove(tb_GianHang);
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
