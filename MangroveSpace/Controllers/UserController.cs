using MangroveSpace.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MangroveSpace.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class UserController : Controller
    {
        private MangroveSpaceEntities db = new MangroveSpaceEntities();
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;


        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }


        // GET: User
        public ActionResult Index()
        {
            try
            {
                IEnumerable<dynamic> aspUser = Global.Sql(db, "SELECT * FROM [AdminInfoView] WHERE Name='CmsNotice';").ToList();
                return View(aspUser);

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }



        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            if (Request.IsLocal)
            {

                return View();
            }
            else
            {
                return Redirect("Login");
            }

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (Request.IsLocal)
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                    var result = await UserManager.CreateAsync(user, model.Password);
                    var role = "CmsNoticeRollID";
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        db.Database.ExecuteSqlCommand("INSERT INTO AspNetUserRoles(UserId, RoleId) VALUES('" + user.Id + "', '" + role + "')");
                        this.Session["Login"] = true;
                        return RedirectToAction("Index", "Home");
                    }
                    AddErrors(result);
                }
                return View(model);
            }
            else
            {
                return Redirect("Login");
            }

        }

        // GET: /User/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPassword(String id)
        {

            if (String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            var viewModel = new ResetPasswordViewModel
            {
                AspNetUsers = aspNetUser,
                AspNetUserRoles = Global.Sql(db, "SELECT [UserId],[RoleId] FROM [AspNetUserRoles];").ToList(),
                AspNetRoles = Global.Sql(db, "SELECT [Id],[Name] FROM [AspNetRoles]").ToList()
            };
            return View(viewModel);
        }


        // POST: /User/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            model.Email = model.AspNetUsers.Email;
            var user = await UserManager.FindByEmailAsync(model.Email);
            model.Code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Users");
            }
            AddErrors(result);
            return View();
        }


        public ActionResult Delete(String id)
        {
            try
            {
                if (String.IsNullOrEmpty(id))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspNetUser aspNetUser = db.AspNetUsers.Find(id);
                if (aspNetUser == null)
                {
                    return HttpNotFound();
                }
                db.AspNetUsers.Remove(aspNetUser);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        //User/Lock
        public ActionResult UnLock(String id)
        {
            try
            {
                if (String.IsNullOrEmpty(id))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspNetUser aspNetUser = db.AspNetUsers.Find(id);
                if (aspNetUser == null)
                {
                    return HttpNotFound();
                }
                aspNetUser.LockoutEnabled = true;
                db.Entry(aspNetUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,ActionName,ControllerName,ErrorTime,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }

        }

        //User/Lock
        public ActionResult Lock(String id)
        {
            try
            {
                if (String.IsNullOrEmpty(id))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspNetUser aspNetUser = db.AspNetUsers.Find(id);
                if (aspNetUser == null)
                {
                    return HttpNotFound();
                }
                aspNetUser.LockoutEnabled = false;
                db.Entry(aspNetUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,ActionName,ControllerName,ErrorTime,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }

        }


    }
}