using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using webtruyen.MahoaMD5;
using webtruyen.Models;

namespace webtruyen.Controllers
{
    public class AccountController : Controller
    {
        private webtruyenContext data = new webtruyenContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Account account)
        {
            if (!ModelState.IsValid) 
            {
                return View(account);
            }
            account.Password = Mahoapass.Mahoa(account.Password);
            data.Accounts.Add(account);
            data.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account account)
        {
            var checkpass = Mahoapass.Mahoa(account.Password);
            var rel = data.Accounts.Where(x => x.Username == account.Username && x.Password == checkpass).Count();
            if(rel == 1) 
            {
                FormsAuthentication.SetAuthCookie(account.Username, true);
                return RedirectToAction("Index","Story");
            }
            else 
            {
                ModelState.AddModelError("FailLogin", "Sai");
                return View(account);
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "User");
        }
    }
}