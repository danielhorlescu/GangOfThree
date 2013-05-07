using System.Web.Mvc;
using MVCSkeleton.Presentation.ApplicationInterfaces;
using MVCSkeleton.Presentation.Authentication;
using MVCSkeleton.Presentation.DTOs;
using MVCSkeleton.Presentation.Models;

namespace MVCSkeleton.Presentation.Controllers
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
        public ActionResult Manage(PasswordModel model, string userName = null)
        {
            SetReturnUrl();
            if (ModelState.IsValid)
            {
                userService.ChangePassword(userName ?? User.Identity.Name, model.OldPassword, model.NewPassword);
                ViewBag.Message = "Password was successfully changed.";
                return RedirectToAction("Manage");
            }
            return View(model);
        }

        private void SetReturnUrl()
        {
            if (Url != null)
                ViewBag.ReturnUrl = Url.Action("Manage");
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
                userService.CreateUser(new UserDTO {Name = model.UserName, Password = model.Password});
                _authenticationService.SignIn(model.UserName, false);
                return RedirectToAction("Index", "Home");
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