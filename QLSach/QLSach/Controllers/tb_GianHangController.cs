using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLSach.Models;
using PagedList;

namespace QLSach.Controllers
{
    public class tb_GianHangController : Controller
    {
        private BookShopEntities db = new BookShopEntities();

        // GET: tb_GianHang
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.MaSortParm = sortOrder == "ma" ? "ma_desc" : "ma";
            ViewBag.TenSortParm = sortOrder == "ten" ? "ten_desc" : "ten";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var model = db.tb_GianHang.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(s => s.maGianHang.Contains(searchString)
                                       || s.tenGianHang.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "ma_desc":
                    model = model.OrderByDescending(s => s.maGianHang);
                    break;
                case "ten":
                    model = model.OrderBy(s => s.tenGianHang);
                    break;
                case "ten_desc":
                    model = model.OrderByDescending(s => s.tenGianHang);
                    break;
                default:
                    model = model.OrderBy(s => s.maGianHang);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
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
