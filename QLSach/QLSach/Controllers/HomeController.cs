using QLSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLSach.Controllers
{
    public class HomeController : Controller
    {
        private BookShopEntities db = new BookShopEntities();

        public ActionResult Index()
        {
            ViewBag.DoanhThu = db.tb_CTPX.Sum(s=>s.thanhTien);
            ViewBag.SoLuongKH = db.tb_PhieuXuat.Distinct().Count();
            if (Session["TaiKhoan"] != null)
            {
                return View();
            }
            //return Redirect("~/Home/Login");
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)                                                    
        {
            var obj = db.tb_NguoiDung.Where(m=>m.TaiKhoan.Equals(email) && m.MatKhau.Equals(password)).FirstOrDefault();
            if (obj == null)
            {
                ViewBag.ThongBao = "Không có tài khoản này";
                return View();
            }
            else
            {
                Session["TaiKhoan"] = email;
                return Redirect("~/Home/Index");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("Login");
        }

        [HttpGet]
        public JsonResult GetSearchValue(string search)
        {
            //var allsearch = db.tb_Sach.Where(x => x.maSach.Contains(search)).ToList();
            //SelectList ls = new SelectList(allsearch, "maSach", "tieuDe");
            var customers = (from a in db.tb_Sach
                             where a.tieuDe.Contains(search)
                             select new
                             {
                                 label = a.tieuDe,
                                 val = a.maSach
                             }).ToList();
            return Json(customers,JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}