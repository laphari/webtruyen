using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtruyen.ModelFake10;
using webtruyen.Modelgethot;
using webtruyen.Models;
using webtruyen.Modeltrichdan;
using webtruyen.Modeltruyendai;
using webtruyen.Modeltruyenngan;

namespace webtruyen.Controllers
{
    public class UserController : Controller
    {
        private webtruyenContext data = new webtruyenContext();

        // GET: User
        public ActionResult Index()
        {
            ViewData["demo15"] = data.Anhbias.ToList();
            var query = from au in data.Anhbias
                        join st in data.Stories
                        on au.IDtensach equals st.StoryId
                        select new getidd
                        {
                            StoryName = st.StoryName,
                            StoryId = st.StoryId,
                            Idanhbia = au.Idanhbia,
                            Imgbia = au.Imgbia,
                        };
            var query1 = from st in data.Stories
                         join ca in data.Categories
                         on st.idcate equals ca.CategoryId
                         join au in data.Authors
                         on st.idtacgia equals au.AuthorId
                         where st.idcate == 8
                         select new Gethot
                         {
                             StoryId = st.StoryId,
                             StoryName = st.StoryName,
                             imghot = st.StoryImage,
                             namphathanh = ca.namphathanh,
                             trangthai = st.StoryIsDone,
                             CategoryId=ca.CategoryId,
                             AuthorId=au.AuthorId,
                             AuthorName=au.AuthorName
                         };
            var query2 = from st in data.Stories
                         join ca in data.Categories
                         on st.idcate equals ca.CategoryId
                         join au in data.Authors
                         on st.idtacgia equals au.AuthorId
                         where st.idcate == 9
                         select new truyenngan
                         {
                             StoryId = st.StoryId,
                             StoryImage = st.StoryImage,
                             StoryName = st.StoryName,
                             AuthorId = au.AuthorId,
                             AuthorName = au.AuthorName,
                             CategoryId = ca.CategoryId,
                             CategoryName = ca.CategoryName,
                             namsx = st.namsx,
                             Ngonngu = st.Ngonngu,
                             Nxb = st.Nxb,
                         };
            var query3 = from st in data.Stories
                         join ca in data.Categories
                         on st.idcate equals ca.CategoryId
                         join au in data.Authors
                         on st.idtacgia equals au.AuthorId
                         where st.idcate == 10
                         select new truyendai
                         {
                             StoryId = st.StoryId,
                             StoryImage = st.StoryImage,
                             StoryName = st.StoryName,
                             AuthorId = au.AuthorId,
                             AuthorName = au.AuthorName,
                             CategoryId = ca.CategoryId,
                             CategoryName = ca.CategoryName,
                             namsx = st.namsx,
                             Ngonngu = st.Ngonngu,
                             Nxb = st.Nxb,
                         };
            var query4 = from st in data.Stories
                         join ca in data.Categories
                         on st.idcate equals ca.CategoryId
                         join au in data.Authors
                         on st.idtacgia equals au.AuthorId
                         where st.idcate == 11
                         select new trichdan
                         {
                             StoryId = st.StoryId,
                             StoryImage = st.StoryImage,
                             StoryName = st.StoryName,
                             AuthorId = au.AuthorId,
                             AuthorName = au.AuthorName,
                             CategoryId = ca.CategoryId,
                             CategoryName = ca.CategoryName,
                             namsx = st.namsx,
                             Ngonngu = st.Ngonngu,
                             Nxb = st.Nxb,
                         };
            var getdulieu = query.OrderByDescending(x => x.Idanhbia).Take(2).ToList();
            ViewData["demo16"] = query1.OrderByDescending(x => x.CategoryId).Take(4).ToList();
            ViewData["demo17"] = query2.OrderByDescending(x => x.CategoryId).Take(5).ToList();
            ViewData["demo18"] = query3.OrderByDescending(x => x.CategoryId).Take(5).ToList();
            ViewData["demo19"] = query4.OrderByDescending(x => x.CategoryId).Take(2).ToList();
            return View(getdulieu);
        }
    }
}