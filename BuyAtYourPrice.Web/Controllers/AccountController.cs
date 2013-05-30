using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BuyAtYourPrice.Membership;
using BuyAtYourPrice.Membership.Model;
using BuyAtYourPrice.Web.Models;
using BuyAtYourPrice.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using NotWebMatrix.Data;

namespace BuyAtYourPrice.Web.Controllers
{
    public class AccountController : Controller
    {
        protected readonly IMembershipProvider MembershipProvider;

        public AccountController(IMembershipProvider membership)
        {
            if (membership == null)
                throw new ArgumentNullException("membership");

            MembershipProvider = membership;
        }

        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (PortalLogIn(model, false))
                {
                    return RedirectToAction("Index", "Home");
                }

                model.Password = String.Empty;
                ModelState.AddModelError("LoginError", "Sorry, your details were incorrect.");
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize]
        public ActionResult LogOut()
        {
            PortalLogOut();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            var model = new SignUpModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                MembershipCreateStatus status;
                var user = MembershipProvider.CreateUser(model.UserName, model.Password, model.Email, out status, model.FullName);

                switch (status)
                {
                    case MembershipCreateStatus.Success:
                        if (user != null)
                        {
                            var loginModel = new LoginModel { Username = user.UserName, Password = user.GetPassword() };
                            if (PortalLogIn(loginModel, false))
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        break;
                    case MembershipCreateStatus.InvalidPassword:
                        ModelState.AddModelError("SignUpError", "Password has to be 8-50 characters, at least on capital letter, one numeral, one special character.");
                        break;
                    default:
                        ModelState.AddModelError("SignUpError", "Error occurred when creating the user.");
                        break;
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Profile(string username)
        {

            return View();
        }

        [AcceptVerbs("POST")]
        public ActionResult Profile(CustomerProfile model)
        {

            return RedirectToAction("Index", "Account");
        }
        
        [AllowAnonymous]
        //[ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful)
            {
                //return RedirectToAction("ExternalLoginFailure");
                return null;
            }

            return null;
        }

        private bool PortalLogIn(LoginModel user, bool createPersistentCookie)
        {
            bool isValid = false;

            if (MembershipProvider.ValidateUser(user.Username, user.Password))
            {
                FormsAuthentication.SetAuthCookie(user.Username, createPersistentCookie);
                isValid = true;
                var currentUser = MembershipProvider.GetUser(user.Username, true) as BusinessUser;
                dynamic customerProfile = UserManager.GetCustomerProfile(currentUser);
                MvcApplication.SetPortalUser(customerProfile);
            }

            return isValid;
        }

        private void PortalLogOut()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null) Response.Cookies.Remove(authTicket.Name);
            }

            FormsAuthentication.SignOut();
            Session.Abandon();
        }
    }


    internal class ExternalLoginResult : ActionResult
    {
        public ExternalLoginResult(string provider, string returnUrl)
        {
            Provider = provider;
            ReturnUrl = returnUrl;
        }

        public string Provider { get; private set; }
        public string ReturnUrl { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
        }
    }
}