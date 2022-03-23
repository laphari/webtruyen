using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtruyen.Models;

namespace webtruyen.Controllers
{
    public class AuthorController : Controller
    {
        private webtruyenContext data = new webtruyenContext();
        // GET: Author
        public ActionResult Index(bool? gift)
        {
            var thongtin = data.Authors.ToList();
            if(gift == true) 
            {
                ViewBag.Thongdieptacgia = true;
            }
            return View(thongtin);
        }
        [ValidateInput(false)]
        public ActionResult Viewcreate() 
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult Create(string tentacgia,HttpPostedFileBase anhtacgia,DateTime namsinh,string motatacgia) 
        {
            Author item = new Author();
            item.AuthorName = tentacgia;
            item.AuthorAvatar = uploadanhtacgia(anhtacgia);
            item.AuthorDateOfBirth = namsinh;
            item.AuthorDescription = motatacgia;
            data.Authors.Add(item);
            data.SaveChanges();
            return RedirectToAction("Index",new{ gift = true});
        }
        public string uploadanhtacgia(HttpPostedFileBase file) 
        {
            var filename = file.FileName;
            var getfile = "../imgtacgia/" + filename;
            file.SaveAs(Server.MapPath(getfile));
            return getfile;
        }
        public ActionResult Detail (int id) 
        {
            var item = data.Authors.Find(id);
            return View(item);
        }
        [ValidateInput(false)]
        public ActionResult Viewupdate(int id) 
        {
            var up = data.Authors.Find(id);
            return View(up);
        }
        [ValidateInput(false)]
        public ActionResult Update(int matacgia,string tentacgia, HttpPostedFileBase anhtacgia, DateTime namsinh, string motatacgia) 
        {
            Author item = new Author();
            item.AuthorId = matacgia;
            item.AuthorName = tentacgia;
            item.AuthorAvatar = uploadanhtacgia(anhtacgia);
            item.AuthorDateOfBirth = namsinh;
            item.AuthorDescription = motatacgia;
            data.Entry(item).State = EntityState.Modified;
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id) 
        {
            var item = data.Authors.Find(id);
            data.Authors.Remove(item);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}