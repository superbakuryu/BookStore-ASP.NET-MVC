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
    public class tb_PhieuXuatController : Controller
    {
        private BookShopEntities db = new BookShopEntities();

        // GET: tb_PhieuXuat
        public ActionResult Index()
        {
            return View(db.tb_PhieuXuat.ToList());
        }

        // GET: tb_PhieuXuat/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_PhieuXuat tb_PhieuXuat = db.tb_PhieuXuat.Find(id);
            if (tb_PhieuXuat == null)
            {
                return HttpNotFound();
            }
            return View(tb_PhieuXuat);
        }

        // GET: tb_PhieuXuat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_PhieuXuat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maPhieuXuat,tenKH,ngayXuat,thanhTien")] tb_PhieuXuat tb_PhieuXuat)
        {
            if (ModelState.IsValid)
            {
                db.tb_PhieuXuat.Add(tb_PhieuXuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_PhieuXuat);
        }

        // GET: tb_PhieuXuat/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_PhieuXuat tb_PhieuXuat = db.tb_PhieuXuat.Find(id);
            if (tb_PhieuXuat == null)
            {
                return HttpNotFound();
            }
            return View(tb_PhieuXuat);
        }

        // POST: tb_PhieuXuat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maPhieuXuat,tenKH,ngayXuat,thanhTien")] tb_PhieuXuat tb_PhieuXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_PhieuXuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_PhieuXuat);
        }

        // GET: tb_PhieuXuat/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_PhieuXuat tb_PhieuXuat = db.tb_PhieuXuat.Find(id);
            if (tb_PhieuXuat == null)
            {
                return HttpNotFound();
            }
            return View(tb_PhieuXuat);
        }

        // POST: tb_PhieuXuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_PhieuXuat tb_PhieuXuat = db.tb_PhieuXuat.Find(id);
            db.tb_PhieuXuat.Remove(tb_PhieuXuat);
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
