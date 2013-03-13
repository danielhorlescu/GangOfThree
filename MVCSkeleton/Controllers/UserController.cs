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

        [AllowAnonymous]
        public ActionResult Manage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(PasswordModel model)
        {
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (ModelState.IsValid)
            {
                try
                {
                    userService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                    ViewBag.Message = "Password was successfullychanged .";
                    return RedirectToAction("Manage");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
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