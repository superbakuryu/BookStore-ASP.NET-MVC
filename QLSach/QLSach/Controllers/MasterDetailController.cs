using QLSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLSach.Controllers
{
    public class MasterDetailController : Controller
    {
        BookShopEntities db = new BookShopEntities();
        // GET: MasterDetail
        public ActionResult Index()
        {
            List<tb_PhieuNhap> lists = db.tb_PhieuNhap.ToList();
            return View(lists);
        }
    }
}