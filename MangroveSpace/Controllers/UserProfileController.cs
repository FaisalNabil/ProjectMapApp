using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MangroveSpace.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace MangroveSpace.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin, BillPay, SendSms, Librarian, CmsNotice")]
    public class UserProfileController : Controller
    {
        private MangroveSpaceEntities db = new MangroveSpaceEntities();
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

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


        // GET: UserProfile
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult ChangePassword()
        {

            var id = db.Database.SqlQuery<string>("SELECT id FROM [dbo].[AspNetUsers] WHERE Email='" + User.Identity.GetUserName() + "'").Single();

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

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ResetPasswordViewModel model)
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
    }
}