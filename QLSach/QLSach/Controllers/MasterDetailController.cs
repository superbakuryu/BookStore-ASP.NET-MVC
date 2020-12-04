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
        [HttpGet]
        public JsonResult GetSearchValue(string search)
        {
            var allsearch = db.tb_Sach.Where(x => x.maSach.Contains(search)).ToList();
            SelectList ls = new SelectList(allsearch, "maSach", "tieuDe");
            return new JsonResult { Data = ls, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}