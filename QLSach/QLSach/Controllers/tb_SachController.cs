using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLSach.Models;
using PagedList;

namespace QLSach.Controllers
{
    public class tb_SachController : Controller
    {
        private BookShopEntities db = new BookShopEntities();

        // GET: tb_Sach
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.MaSortParm = sortOrder == "ma"? "ma_desc" : "ma";
            ViewBag.TenSortParm = sortOrder == "ten" ? "ten_desc" : "ten";
            ViewBag.SoLuongSortParm = sortOrder == "soluong" ? "soluong_desc" : "soluong";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var models = db.tb_Sach.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                models = models.Where(s => s.maSach.Contains(searchString)
                                       || s.tieuDe.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "ma_desc":
                    models = models.OrderByDescending(s => s.maSach);
                    break;
                case "ten":
                    models = models.OrderBy(s => s.tieuDe);
                    break;
                case "ten_desc":
                    models = models.OrderByDescending(s => s.tieuDe);
                    break;
                case "soluong":
                    models = models.OrderBy(s => s.soLuongTon);
                    break;
                case "soluong_desc":
                    models = models.OrderByDescending(s => s.soLuongTon);
                    break;
                default:
                    models = models.OrderBy(s => s.maSach);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(models.ToPagedList(pageNumber, pageSize));
        }

        // GET: tb_Sach/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Sach tb_Sach = db.tb_Sach.Find(id);
            if (tb_Sach == null)
            {
                return HttpNotFound();
            }
            return View(tb_Sach);
        }

        // GET: tb_Sach/Create
        public ActionResult Create()
        {
            ViewBag.maGianHang = new SelectList(db.tb_GianHang, "maGianHang", "tenGianHang");
            ViewBag.maNXB = new SelectList(db.tb_NXB, "maNXB", "tenNXB");
            return View();
        }

        // POST: tb_Sach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[HttpPost, ValidateInput(false)]
        public ActionResult Create(HttpPostedFileBase anh, [Bind(Include = "maSach,tieuDe,tacGia,namXuatBan,giaBia,maNXB,soLuongTon,maGianHang,moTa")] tb_Sach tb_Sach)
        {
            if(anh!=null)
            {
                string path = Path.Combine(Server.MapPath("~/Anh"), Path.GetFileName(anh.FileName));
                anh.SaveAs(path);
                tb_Sach.anh = anh.FileName;
            }
            if (ModelState.IsValid)
            {
                db.tb_Sach.Add(tb_Sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maGianHang = new SelectList(db.tb_GianHang, "maGianHang", "tenGianHang", tb_Sach.maGianHang);
            ViewBag.maNXB = new SelectList(db.tb_NXB, "maNXB", "tenNXB", tb_Sach.maNXB);
            return View(tb_Sach);
        }

        // GET: tb_Sach/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Sach tb_Sach = db.tb_Sach.Find(id);
            if (tb_Sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.maGianHang = new SelectList(db.tb_GianHang, "maGianHang", "tenGianHang", tb_Sach.maGianHang);
            ViewBag.maNXB = new SelectList(db.tb_NXB, "maNXB", "tenNXB", tb_Sach.maNXB);
            return View(tb_Sach);
        }

        // POST: tb_Sach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        [HttpPost, ValidateInput(false)]  //Không cho validate dữ liệu
        public ActionResult Edit(HttpPostedFileBase anh, tb_Sach tb_Sach)
        {
            if (anh != null)
            {
                string path = Path.Combine(Server.MapPath("~/Anh"), Path.GetFileName(anh.FileName));
                anh.SaveAs(path);
                tb_Sach.anh = anh.FileName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(tb_Sach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maGianHang = new SelectList(db.tb_GianHang, "maGianHang", "tenGianHang", tb_Sach.maGianHang);
            ViewBag.maNXB = new SelectList(db.tb_NXB, "maNXB", "tenNXB", tb_Sach.maNXB);
            return View(tb_Sach);
        }

        // GET: tb_Sach/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Sach tb_Sach = db.tb_Sach.Find(id);
            if (tb_Sach == null)
            {
                return HttpNotFound();
            }
            return View(tb_Sach);
        }

        // POST: tb_Sach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_Sach tb_Sach = db.tb_Sach.Find(id);
            db.tb_Sach.Remove(tb_Sach);
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
