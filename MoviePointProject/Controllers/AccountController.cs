using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoviePoint.ViewModel;
using System.Security.Claims;

namespace MoviePoint.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController
            (UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = _userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
      
        public IActionResult Registration()
        {
            return View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegistrationViewModel newUserVM)
        //not all property model + extra property for view Confirm + validation [][][]
        {
            if (ModelState.IsValid)
            {
                //map from vm to model
                IdentityUser userModel = new IdentityUser();
                userModel.UserName = newUserVM.UserName;
                userModel.PasswordHash = newUserVM.Password;
                userModel.Email = newUserVM.Email;
                userModel.PhoneNumber = newUserVM.Phone;
               

                //save data by create account (6 A a $ 7)
                IdentityResult result =
                    await userManager.CreateAsync(userModel, newUserVM.Password);//object insert db

                if (result.Succeeded)
                {
                    //assign user to Admin Role
                    await userManager.AddToRoleAsync(userModel, "User");//insert row UserRole
                    //create cookie
                    //???
                    List<Claim> addClaim = new List<Claim>();
                    addClaim.Add(new Claim("Intake", "43"));
                    await signInManager.SignInWithClaimsAsync(userModel, false, addClaim);
					//await  signInManager.SignInAsync(userModel, false); //session cookie register
					return RedirectToAction("Home", "Home");
				}
				else
                {
                    //some issue ==>send user view
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(newUserVM);
        }

		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel userVmReq)//username,password,remeberme 
		{
			if (ModelState.IsValid)
			{
				//check valid  account "found in db"
				IdentityUser userModel =
					await userManager.FindByNameAsync(userVmReq.Username);
				if (userModel != null)
				{
					//cookie
					Microsoft.AspNetCore.Identity.SignInResult rr =
						await signInManager.PasswordSignInAsync(userModel, userVmReq.Password, userVmReq.rememberMe, false);
					//check cookie
					if (rr.Succeeded)
						return RedirectToAction("Home","Home");
				}
				else
				{
					ModelState.AddModelError("", "User Not Found :( ");
				}
			}
			return View(userVmReq);
		}


		public async Task<IActionResult> signOut()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction("Login");
		}
	}
}
