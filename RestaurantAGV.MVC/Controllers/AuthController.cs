using RestaurantAGV.MVC.Models.Auth;
using RestaurantAGV.MVC.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace RestaurantAGV.MVC.Controllers;


public class AuthController : Controller{

    public AuthController()
    {}

    [HttpGet]
    public IActionResult AdminSignin(){
        return View(new AdminSigninModel());
    }

    [HttpPost]
    public async Task<IActionResult> AdminSignin(AdminSigninModel signinModel){


        if (signinModel.Email == "fam@founder.com" && signinModel.Password == "fam123"){

            var claims = new List<Claim>(){
                new Claim("roles",RoleConst.AdminRole),
                new Claim("email","fam@founder.com")
            };

            var identity = new ClaimsIdentity(claims,AuthConstants.CookieScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(AuthConstants.CookieScheme,principal);

            return RedirectToAction("ReceiverOrder","Admin");
        }

        signinModel.ErrorMessage = "The email and password is invalid";
        return View(signinModel);

    }

    [HttpGet]
    public ViewResult CustomerSignin(string returnUrl){
        CustomerSigninModel customerSigninModel = new(){
            ReturnUrl = returnUrl
        };

        return View(customerSigninModel);
    }

    [HttpPost]
    public async Task<IActionResult> CustomerSignin(CustomerSigninModel customerModel){
        
        // Check credencial in the Dbcontext
        if (customerModel.Credencial == "VANS"){
            // Generate the security context based on the matched customer entity
            var claims = new List<Claim>(){
                new Claim("roles",RoleConst.CustomerRole),
                new Claim("table","2"),
                new Claim("address","In room")
            };

            var identity = new ClaimsIdentity(claims,AuthConstants.CookieScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(AuthConstants.CookieScheme,principal);
            
            return RedirectPermanent(customerModel.ReturnUrl??"/");
        }
        // If there is no specified credencial in the database, Then return the error message
        customerModel.ErrorMessage = "There is no specified Credencial, Please specify the correct credencial given by Stuff worker.";

        return View(customerModel);
    }


    public ViewResult Forbidden(){
        return View();
    }

}