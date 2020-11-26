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
            if (Session["TaiKhoan"] != null)
                return View();
            return Redirect("~/Home/Login");
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

        [HttpPost]
        public JsonResult GetSearchValue(string search)
        {
            List<tb_Sach> allsearch = db.tb_Sach.Where(x => x.maSach.Contains(search)).Select(x => new tb_Sach
            {
                maSach = x.maSach,
                tieuDe = x.tieuDe
            }).ToList();
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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