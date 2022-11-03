using RestaurantAGV.MVC.Models.Auth;
using RestaurantAGV.MVC.Constants;
using Microsoft.AspNetCore.Mvc;
using RestaurantAGV.MVC.Models.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

using RestaurantAGV.MVC.Services.Interfaces;

namespace RestaurantAGV.MVC.Controllers;


public class AuthController : Controller{

    private readonly ICustomerRepository _customerRepo;


    public AuthController(ICustomerRepository customerRepository)
    {
        _customerRepo = customerRepository;
    }

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
        
        if (!ModelState.IsValid || string.IsNullOrEmpty(customerModel.Credencial))
            return View(customerModel);
        
        Customer? signedIn = await _customerRepo.RetrieveByIdAsync(customerModel.Credencial); 

        // Check credencial in the Dbcontext
        if (signedIn != null){
            
            // Generate the security context based on the matched customer entity
            var claims = new List<Claim>(){
                new Claim(ClaimConstants.ClaimRole,RoleConst.CustomerRole),
                new Claim(ClaimConstants.CustomerClaimId, signedIn.Id),
                new Claim(ClaimConstants.TableClaimId, signedIn.TableId.ToString()),
                new Claim(ClaimConstants.BasketClaimId, signedIn.Basket?.Id.ToString() ?? ""),
                new Claim(ClaimConstants.BillClaimId, signedIn.BillOrder?.Id.ToString() ?? "")
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