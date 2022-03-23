using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtruyen.ModelFake2;
using webtruyen.Modelfake5;
using webtruyen.ModelFake6;
using webtruyen.Models;

namespace webtruyen.Controllers
{
    public class AnhbiaController : Controller
    {
        private webtruyenContext data = new webtruyenContext();
        // GET: Anhbia
        public ActionResult Index(bool? cl,int? page, bool? up)
        {
            var query = from ab in data.Anhbias
                        join ca in data.Categories
                        on ab.IDtheloaibia equals ca.CategoryId
                        join st in data.Stories
                        on ab.IDtensach equals st.StoryId
                        select new Getcateandanbia
                        {
                            Idanhbia = ab.Idanhbia,
                            Nameanhbia = ab.Nameanhbia,
                            motaveanhbia = ab.motaveanhbia,
                            Imgbia = ab.Imgbia,
                            ngaytao = ab.ngaytao,
                            theloaibia = ab.theloaibia,
                            CategoryId = ca.CategoryId,
                            CategoryName = ca.CategoryName,
                            StoryId=st.StoryId,
                            StoryName=st.StoryName,

                        };
            if(cl == true) 
            {
                ViewBag.Danglen = true;
            }
            if (up == true)
            {
                ViewBag.updatee = true;
            }
            var thongtin = query.ToList();
            var pagesize = 3;
            if (page == null)
            {
                page = 1;
            }
            var totall = thongtin.Count();
            var paging = (page - 1) * pagesize;
            var result = thongtin.OrderBy(x => x.Idanhbia).Skip(paging ?? 1).Take(pagesize);
            var numberpage = 0;
            if (totall % pagesize == 0)
            {
                numberpage = totall / pagesize;
            }
            else
            {
                numberpage = totall / pagesize + 1;
            }
            ViewData["totallpage"] = numberpage;
            return View(result.ToList());
        }
        public string Uploadanhbia(HttpPostedFileBase file) 
        {
            var filename = file.FileName;
            var getfile = "../Imgbia/" + filename;
            file.SaveAs(Server.MapPath(getfile));
            return getfile;
        }
        [ValidateInput(false)]
        public ActionResult Viewcreate() 
        {
            ViewData["demo9"] = data.Stories.ToList();
            ViewData["demo10"] = data.Categories.ToList();
            var query = from st in data.Stories
                        join ca in data.Categories
                        on st.idcate equals ca.CategoryId
                        select new getcateandst
                        {
                            StoryId = st.StoryId,
                            StoryName = st.StoryName,
                            CategoryId = ca.CategoryId,
                            CategoryName = ca.CategoryName,
                        };
            var item = query.ToList();
            return View(item);
        }
        [ValidateInput(false)]
        public ActionResult Create(int trichdan,int theloaibia,string tenanhbia,HttpPostedFileBase anhbia,DateTime ngaytaoanhbia,string motaanhbia) 
        {
            Anhbia item = new Anhbia();
            item.IDtensach = trichdan;
            item.Nameanhbia = tenanhbia;
            item.Imgbia = Uploadanhbia(anhbia);
            item.motaveanhbia = motaanhbia;
            item.ngaytao = ngaytaoanhbia;
            item.IDtheloaibia = theloaibia;
            data.Anhbias.Add(item);
            data.SaveChanges();
            return RedirectToAction("Index",new {cl = true});
        }
        public ActionResult Delete(int id) 
        {
            var item = data.Anhbias.Find(id);
            data.Anhbias.Remove(item);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id) 
        {
            var item = data.Anhbias.Find(id);
            return View(item);
        }
        public ActionResult Search(string search) 
        {
            var result = data.Anhbias.Where(x => x.Nameanhbia.Contains(search)).Select(x => new Getcateandanbia
            {
               Nameanhbia=x.Nameanhbia,
               Imgbia=x.Imgbia,
            }
            );
            return View(result);
        }
        [ValidateInput(false)]
        public ActionResult Viewupdate(int id) 
        {
            ViewData["demo11"] = data.Stories.ToList();
            ViewData["demo12"] = data.Categories.ToList();
            var query = from ab in data.Anhbias
                        join st in data.Stories
                        on ab.IDtensach equals st.StoryId
                        join ca in data.Categories
                        on ab.IDtheloaibia equals ca.CategoryId
                        where ab.Idanhbia == id
                        select new Getup
                        {
                            Idanhbia = ab.Idanhbia,
                            Nameanhbia = ab.Nameanhbia,
                            motaveanhbia = ab.motaveanhbia,
                            ngaytao = ab.ngaytao,
                            Imgbia = ab.Imgbia,
                            StoryId = st.StoryId,
                            StoryName = st.StoryName,
                            CategoryId = ca.CategoryId,
                            CategoryName = ca.CategoryName,
                        };
            var item = query.FirstOrDefault();
            return View(item);
        }
        [ValidateInput(false)]
        public ActionResult Update(int Idbia,int trichdan, int theloaibia, string tenanhbia, HttpPostedFileBase anhbia, DateTime ngaytaoanhbia, string motaanhbia) 
        {

            Anhbia item = new Anhbia();
            item.Idanhbia = Idbia;
            item.IDtensach = trichdan;
            item.Nameanhbia = tenanhbia;
            item.Imgbia = Uploadanhbia(anhbia);
            item.motaveanhbia = motaanhbia;
            item.ngaytao = ngaytaoanhbia;
            item.IDtheloaibia = theloaibia;
            data.Entry(item).State = EntityState.Modified;
            data.SaveChanges();
            return RedirectToAction("Index", new { up = true});
        }
    }
}