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
        private DB_QLHTEntities db = new DB_QLHTEntities();
        // GET: /Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            // Check if any field is empty
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var email = model.Email.Trim();
                var password = model.Password.Trim();

                var f_password = PasswordUtil.GetMD5(password);
                var user = db.Users.SingleOrDefault(s => s.Email.Equals(email) && s.C_Password.Equals(f_password));

                if (user != null)
                {
                    // Add Session
                    Session["User"] = user;

                    if (user.RoleID == 1)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    } else if (user.RoleID == 2)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Host" });
                    } else if (user.RoleID == 4)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Author" });
                    } else
                    {
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");
                    return View(model);
                }
            }

            return View(model);
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
        public ActionResult Register(RegisterModel model)
        {
            if (string.IsNullOrEmpty(model.FullName) || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password) ||
                string.IsNullOrEmpty(model.ConfirmPassword))
            {
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Email == model.Email.Trim());
                if (check == null)
                {
                    DateTime dt = DateTime.Now;
                    var user = new User
                    {
                        FullName = model.FullName,
                        Email = model.Email,
                        C_Password = PasswordUtil.GetMD5(model.Password),
                        RoleID = 4,
                        CreatedAt = dt
                    };
                    //db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Account"); // Chuyển đến trang đăng nhập sau khi đăng ký thành công
                }
                else
                {
                    ModelState.AddModelError("", "Email đã tồn tại!");
                    return View(model);
                }
            }
            return View(model);
        }
        // POST: /Account/Logout
        public ActionResult Logout()
        {
            Session.Clear(); // Remove session
            return RedirectToAction("Index", "Home");
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
                return View(model);
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