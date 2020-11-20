using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Security;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/login")]
    public class LoginController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        private SecurityManager securityManager = new SecurityManager();
        public LoginController(DatabaseContext _db)
        {
            db = _db;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("proccess")]
        public IActionResult Proccess(string username, string password)
        {
            var account = proccesLogin(username, password);

            if(account != null )
            {

                securityManager.SignIn(this.HttpContext, account);
                return RedirectToAction("DashBoard");

            } else {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }

        private Account proccesLogin(string username, string password)
        {
            var account = db.Accounts.SingleOrDefault(a => a.Username.Equals(username));
            if (account != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, account.Password))
                {
                    return account;
                }

            }
            return null;
        }

        [Route("signOut")]
        public IActionResult SignOut()
        {
            return View();
        }

        [Route("accessdenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
