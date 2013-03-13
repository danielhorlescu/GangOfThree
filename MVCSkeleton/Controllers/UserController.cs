using System;
using System.Web.Mvc;
using MVCSkeleton.ApplicationInterfaces;
using MVCSkeleton.Authentication;
using MVCSkeleton.DTOs;
using MVCSkeleton.Models;

namespace MVCSkeleton.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IFormsAuthentication _authenticationService;

        public UserController(IUserService userService, IFormsAuthentication authenticationService)
        {
            this.userService = userService;
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && userService.IsValid(model.UserName, model.Password))
            {
                _authenticationService.SignIn(model.UserName, model.RememberMe);
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            return Url.IsLocalUrl(returnUrl) ? (ActionResult) Redirect(returnUrl) : RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (ModelState.IsValid)
            {
                try
                {
                    userService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                    return RedirectToAction("Manage", new {Message = "Password was successfullychanged ."});
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }

                // ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
            }

            ////  else
            //{
            //    // User does not have a local password so remove any validation errors caused by a missing
            //    // OldPassword field
            //    ModelState state = ModelState["OldPassword"];
            //    if (state != null)
            //    {
            //        state.Errors.Clear();
            //    }

            //    if (ModelState.IsValid)
            //    {
            //        try
            //        {
            //            //    WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword);
            //            //     return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
            //        }
            //        catch (Exception e)
            //        {
            //            ModelState.AddModelError("", e);
            //        }
            //    }
            //}

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userService.CreateUser(new UserDTO {Name = model.UserName, Password = model.Password});
                    _authenticationService.SignIn(model.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _authenticationService.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}