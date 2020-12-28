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
    public class tb_NguoiDungController : Controller
    {
        private BookShopEntities db = new BookShopEntities();

        // GET: tb_NguoiDung
        public ActionResult Index()
        {
            return View(db.tb_NguoiDung.ToList());
        }

        // GET: tb_NguoiDung/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NguoiDung tb_NguoiDung = db.tb_NguoiDung.Find(id);
            if (tb_NguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(tb_NguoiDung);
        }

        // GET: tb_NguoiDung/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_NguoiDung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaiKhoan,MatKhau")] tb_NguoiDung tb_NguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.tb_NguoiDung.Add(tb_NguoiDung);
                db.SaveChanges();
                setAlert("Thêm người dùng thành công","success");
                return RedirectToAction("Index");
            }

            return View(tb_NguoiDung);
        }

        // GET: tb_NguoiDung/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NguoiDung tb_NguoiDung = db.tb_NguoiDung.Find(id);
            if (tb_NguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(tb_NguoiDung);
        }

        // POST: tb_NguoiDung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaiKhoan,MatKhau")] tb_NguoiDung tb_NguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_NguoiDung).State = EntityState.Modified;
                db.SaveChanges();
                setAlert("Sửa người dùng thành công", "success");
                return RedirectToAction("Index");
            }
            return View(tb_NguoiDung);
        }

        // GET: tb_NguoiDung/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NguoiDung tb_NguoiDung = db.tb_NguoiDung.Find(id);
            if (tb_NguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(tb_NguoiDung);
        }

        // POST: tb_NguoiDung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_NguoiDung tb_NguoiDung = db.tb_NguoiDung.Find(id);
            db.tb_NguoiDung.Remove(tb_NguoiDung);
            db.SaveChanges();
            setAlert("Xóa người dùng thành công", "success");
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
        
        protected void setAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if(type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}
