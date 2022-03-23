using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtruyen.Models;

namespace webtruyen.Controllers
{
    public class CategoryController : Controller
    {
        private webtruyenContext data = new webtruyenContext();
        // GET: Category
        public ActionResult Index()
        {
            var cate = data.Categories.ToList();
            return View(cate);
        }
        public string uploadimgcate(HttpPostedFileBase file) 
        {
            var filename = file.FileName;
            var getfile = "../Imgcate/" + filename;
            file.SaveAs(Server.MapPath(getfile));
            return getfile;
        }
        [ValidateInput(false)]
        public ActionResult Viewcreate() 
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult Create(string tentheloai,HttpPostedFileBase anhtheloai,string motatheloai,HttpPostedFileBase anhhot,string trangthaii,string namphathanhh)
        {
            Category item = new Category();
            item.CategoryName = tentheloai;
            item.imgcate = uploadimgcate(anhtheloai);
            item.CategoryDesctiption = motatheloai;
            item.imghot = uploadimgcate(anhhot);
            item.trangthai = trangthaii;
            item.namphathanh = namphathanhh;
            data.Categories.Add(item);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id) 
        {
            var detail = data.Categories.Find(id);
            return View(detail);
        }
        public ActionResult Delete(int id) 
        {
            var item = data.Categories.Find(id);
            data.Categories.Remove(item);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Viewupdate(int id)
        {
            var getupdate = data.Categories.Find(id);
            return View(getupdate);
        }
       
    }
}