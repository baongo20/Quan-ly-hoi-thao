using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Do_An.Models;
using Do_An.Utils;
using System.Data.Entity.Validation;
using Do_An.ViewModels;

namespace Do_An.Controllers
{
    public class AccountController : Controller
    {
        private readonly DB_QLHTEntities db = new DB_QLHTEntities();
        // GET: /Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User _user)
        {
            var email = _user.Email;
            var password = _user.C_Password;

            var f_password = PasswordUtil.GetMD5(password);
            var data = db.Users.SingleOrDefault(s => s.Email.Equals(email) && s.C_Password.Equals(f_password));

            if (data != null)
            {
                // Add session
                Session["User"] = data;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginFail = "Tài khoản hoặc mật khẩu không đúng!";
                return View();
            }
        }
        // GET: /Account/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Email == _user.Email.Trim());
                if (check == null)
                {
                    DateTime dt = DateTime.Now;
                    _user.C_Password = PasswordUtil.GetMD5(_user.C_Password);
                    _user.RoleID = 4;
                    _user.CreatedAt = dt;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Account"); // Chuyển đến trang đăng nhập sau khi đăng ký thành công
                }
                else
                {
                    ViewBag.Error = "Email đã tồn tại!";
                    return View();
                }
            }
            return View();
        }
        // Logout
        public ActionResult Logout()
        {
            Session.Clear(); // Remove session
            return RedirectToAction("Login", "Account");
        }
        // GET: /Account/ResetPassword
        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }
        // POST: /Account/ResetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword([Bind(Include = "Email, Password, ConfirmPassword")]ResetPasswordModel model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.ConfirmPassword))
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                var user = db.Users.SingleOrDefault(u => u.Email.Equals(model.Email));

                if (user != null)
                {
                    user.C_Password = PasswordUtil.GetMD5(model.Password);

                    db.SaveChanges();
                    ViewBag.Success = "Mật khẩu đã được cập nhật thành công.";
                    return View(model);
                }
                else
                {
                    ViewBag.Error = "Không tìm thấy tài khoản với email đã nhập.";
                    return View(model);
                }
            }

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}