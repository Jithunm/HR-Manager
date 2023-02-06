using Firebase.Auth;
using HR_Manager.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HR_Manager.Controllers
{
    public class AccountController : Controller
    {
        private static string Apikey = "AIzaSyC-EPG64VbQSIo79UA2EEpi53wgZLjRgVc";
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]

        public async Task<ActionResult> SignUp(SignUpModel model)
        {
            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig(Apikey));
                var a = await auth.CreateUserWithEmailAndPasswordAsync(model.email, model.password, model.name, true);
                //Add validation message here.
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                if (this.Request.IsAuthenticated)
                {
                    
                }
            }
            catch(Exception ex)
            {
               
            }
            return this.View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model,string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var auth = new FirebaseAuthProvider(new FirebaseConfig(Apikey));
                    var logVariable = await auth.SignInWithEmailAndPasswordAsync(model.email, model.password);

                    string token = logVariable.FirebaseToken;
                    var user = logVariable.User;
                    if(token != "")
                    {
                        this.SignInUser(user.Email,token,false);
                        return this.RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Username or Password");
                    }
                }
            }
            catch(Exception ex)
            {
               
            }
            return this.View(model);
        }
        private void SignInUser(string email,string token,bool isPersistant)
        {
            var claims = new List<Claim>();
            try
            {

                claims.Add(new Claim(ClaimTypes.Email, email));
                claims.Add(new Claim(ClaimTypes.Authentication, token));

                var claimIdentities = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistant }, claimIdentities);
            }   
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void ClaimIdentities(string username, bool isPersistant)
        {
            var claims = new List<Claim>();

            try
            {
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            }
            catch(Exception ex)
            {

            }

        }

       private ActionResult RedirectToLocal(string returnUrl)
        {
            try
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    //return this.Redirect(returnUrl);
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return this.RedirectToAction("LogOff", "Account");
        }
        [HttpGet]
        public ActionResult LogOff()
        {
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("login", "Account");
        }

        

    }
}