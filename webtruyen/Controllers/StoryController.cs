using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtruyen.ModelFake;
using webtruyen.ModelFake1;
using webtruyen.Modelgetauandcate;
using webtruyen.Models;

namespace webtruyen.Controllers
{
    public class StoryController : Controller
    {
        private webtruyenContext data = new webtruyenContext();
        // GET: Story
        [Authorize]
        public ActionResult Index(int? page,bool? gift)
        {
            //var thongtin = data.Stories.ToList();
            var query = from tg in data.Stories
                        join au in data.Authors
                        on tg.idtacgia equals au.AuthorId
                        join ca in data.Categories
                        on tg.idcate equals ca.CategoryId
                        select new Gettacgia
                        {
                            ID = tg.StoryId,
                            StoryName = tg.StoryName,
                            StoryImage = tg.StoryImage,
                            StoryDescription = tg.StoryDescription,
                            StoryIsDone = tg.StoryIsDone,
                            Storyauthor = tg.Storyauthor,
                            Storycate = tg.Storycate,
                            AuthorName = au.AuthorName,
                            CategoryName=ca.CategoryName
                        };
            var thongtin = query.ToList();
            var pagesize = 3;
            if(page == null) 
            {
                page = 1;
            }
            var totall = thongtin.Count();
            var paging = (page - 1) * pagesize;
            var result = thongtin.OrderBy(x => x.ID).Skip(paging ?? 1).Take(pagesize);
            var numberpage = 0;
            if(totall % pagesize == 0) 
            {
                numberpage = totall / pagesize;
            }
            else 
            {
                numberpage = totall / pagesize + 1;
            }
            ViewData["totallpage"] = numberpage;
            if(gift == true) 
            {
                ViewBag.Thongdiep = true;
            }
            return View(result.ToList());
        }
        public string Uploadstory(HttpPostedFileBase file) 
        {
            var filename = file.FileName;
            var getfile = "../Imgstory/" + filename;
            file.SaveAs(Server.MapPath(getfile));
            return getfile;
        }
        [ValidateInput(false)]
        public ActionResult Viewcreate() 
        {
            ViewData["demo"] = data.Authors.ToList();
            ViewData["demo1"] = data.Categories.ToList();
            var query = from cate in data.Categories
                        join au in data.Authors
                        on cate.idtacgiaintheloai equals au.AuthorId
                        select new Getauandca
                        {
                            AuthorId = au.AuthorId,
                            AuthorName = au.AuthorName,
                            CategoryId = cate.CategoryId,
                            CategoryName = cate.CategoryName
                        };
            var list = query.ToList();
            return View(list);
        }
        [ValidateInput(false)]
        public ActionResult Create(int gettacgia, string tensach, HttpPostedFileBase anhsach, string trangthai, string tacgia, int theloai, DateTime ngaytao, DateTime ngaysua, DateTime ngayxoa,string motasach,string nhaxuatban,string ngonngutruyen,string namsxtruyen)
        {
            Story item = new Story();
            item.idtacgia = gettacgia;
            item.StoryName = tensach;
            item.StoryImage = Uploadstory(anhsach);
            item.StoryIsDone = trangthai;
            item.Storyauthor = tacgia;
            item.idcate = theloai;
            item.StoryCreated = ngaytao;
            item.StoryUpdated = ngaysua;
            item.StoryDeleted = ngayxoa;
            item.StoryDescription = motasach;
            item.Nxb = nhaxuatban;
            item.Ngonngu = ngonngutruyen;
            item.namsx = namsxtruyen;
            data.Stories.Add(item);
            data.SaveChanges();
            return RedirectToAction("Index", new { gift = true});
        }
        public ActionResult Remove(int id) 
        {
            var item = data.Stories.Find(id);
            data.Stories.Remove(item);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id) 
        {
            var item = data.Stories.Find(id);
            return View(item);
        }
        public ActionResult Search(string search) 
        {
            var result = data.Stories.Where(x => x.StoryName.Contains(search)).Select(x => new Gettacgia
            {
              ID=x.StoryId,
              StoryName=x.StoryName,
              StoryImage=x.StoryImage,
              StoryIsDone=x.StoryIsDone,
            }
            );
            return View(result);
        }
        [ValidateInput(false)]
        public ActionResult Viewupdate(int id) 
        {
            ViewData["demo3"] = data.Authors.ToList();
            ViewData["demo4"] = data.Categories.ToList();
            var query = from st in data.Stories
                        join au in data.Authors
                        on st.idtacgia equals au.AuthorId
                        join ca in data.Categories
                        on   st.idcate equals ca.CategoryId
                        where st.StoryId == id
                        select new Getstory
                        {
                            StoryId = st.StoryId,
                            Storyauthor=st.Storyauthor,
                            Storycate=st.Storycate,
                            StoryCreated=st.StoryCreated,
                            StoryDeleted=st.StoryDeleted,
                            StoryDescription=st.StoryDescription,
                            StoryIsDone=st.StoryIsDone,
                            StoryName=st.StoryName,
                            StoryImage=st.StoryImage,
                            StoryUpdated=st.StoryUpdated,
                            AuthorName=au.AuthorName,
                            AuthorId=au.AuthorId,
                            CategoryId=ca.CategoryId,
                            CategoryName=ca.CategoryName,
                        };
            var item = query.FirstOrDefault();
            return View(item);
        }
        [ValidateInput(false)]
        public ActionResult Update(int masach,int gettacgia1, string tensach, HttpPostedFileBase anhsach, string trangthai, int theloai1, DateTime ngaytao, DateTime ngaysua, DateTime ngayxoa, string motasach, string nhaxuatban, string ngonngutruyen, string namsxtruyen) 
        {
            Story item = new Story();
            item.StoryId = masach;
            item.idtacgia = gettacgia1;
            item.StoryName = tensach;
            item.StoryImage = Uploadstory(anhsach);
            item.StoryIsDone = trangthai;
            item.idcate = theloai1;
            item.StoryCreated = ngaytao;
            item.StoryUpdated = ngaysua;
            item.StoryDeleted = ngayxoa;
            item.StoryDescription = motasach;
            item.Nxb = nhaxuatban;
            item.Ngonngu = ngonngutruyen;
            item.namsx = namsxtruyen;
            data.Entry(item).State = EntityState.Modified;
            data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}