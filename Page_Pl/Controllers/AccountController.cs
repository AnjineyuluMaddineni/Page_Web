using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Page_DAL.Models;
using Page_Pl.ModelsView;
using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Page_Pl.Controllers
{
	
	public class AccountController : Controller
	{
		private readonly UserManager<ApplictionUser> _userManager;
		private readonly SignInManager<ApplictionUser> _signInManager;

		public AccountController(UserManager<ApplictionUser> userManager,
			SignInManager<ApplictionUser> signInManager)
        {
			_userManager = userManager;
			_signInManager = signInManager;
		}
		#region Register
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(ApplicationUserView model)
		{
			if (ModelState.IsValid)
			{
				var User = new ApplictionUser
				{
					FName = model.FName,
					LName = model.LName,
					Email = model.Email,
					UserName = model.Email.Split('@')[0],
					IsAgree = model.IsAgree

				};
				var res=await _userManager.CreateAsync(User, model.Password);	
				if (res.Succeeded)return RedirectToAction("Login");
				else
				{
					foreach(var E in res.Errors)
					{
						ModelState.AddModelError(string.Empty, E.Description);
					}
				}	
			}
			return View(model);
		}
        #endregion

        #region Login
        [HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginModelView model)
		{
			if(ModelState.IsValid)
			{
				var User= await _userManager.FindByEmailAsync(model.Email);
				if(User is not null)
				{
				  var res= await _userManager.CheckPasswordAsync(User, model.Password);
					if (res)
					{
						var ResLogin=await _signInManager.PasswordSignInAsync(User,model.Password,model.RememberMe,false);
						if (ResLogin.Succeeded)return RedirectToAction("Index", "Home");
						 
					}
					else ModelState.AddModelError(string.Empty, "Password Is Not Correct");


				}
				else ModelState.AddModelError(string.Empty, "Email Not Found");
				
			}
			return View(model);
		}
        #endregion

		public async Task<IActionResult> Sign_Out()
		{
			 await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(Login ));
		}

    }
}
