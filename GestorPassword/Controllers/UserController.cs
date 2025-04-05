using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Applitation.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using GestorPassword.Infrastructure.Identity.Entities;
using GestorPassword.Core.Application.ViewModel.User;
using GestorPassword.Core.Application.Dtos.Account.Response;
using GestorPassword.Core.Application.Dtos.Account;
using GestorPassword.Core.Application.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace SocialNetwork.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplitationUser> userManager;

        public UserController(IUserService userService, UserManager<ApplitationUser> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }
        // GET: UserController
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel loginView)
        {
            if (!ModelState.IsValid)
            {
                return View(loginView);
            }
            AuthenticationResponse authentication = await userService.LoginAsync(loginView);
            if (authentication != null && authentication.HasError != true)
            {
                HttpContext.Session.Set<AuthenticationResponse>("user", authentication);
                return RedirectToRoute(new { controller = "PasswordItem", action = "Index" });
            }
            else
            {
                loginView.HasError = authentication!.HasError;
                loginView.Error = authentication.Error;
                return View(loginView);
            }

            
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View(new SaveUserViewModel ());
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SaveUserViewModel saveUser)
        {
            try
            {
                
                if (!ModelState.IsValid)
                {
                    return View(saveUser);
                }
                var origin = Request.Headers["origin"];
                RegisterResponse request = await userService.RegisterAsync(saveUser , origin!);

                if (request.HasError)
                {
                    saveUser.HasError = request!.HasError;
                    saveUser.Error = request.Error;
                    return View(saveUser);
                }
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> ConfirmEmail(string userId, string token)
        {
            string response = await userService.ConfirmEmailAsync(userId, token);
            return View("ConfirmEmail", response);
        }

        public ActionResult ForgotPassword()
        {
            return View(new ForgotPasswordViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(forgotPasswordViewModel);
                }
                var origin = Request.Headers["origin"];
                ForgotPasswordReponse request = await userService.ForgotPasswordAsync(forgotPasswordViewModel, origin!);

                if (request.HasError)
                {
                    forgotPasswordViewModel.HasError = request!.HasError;
                    forgotPasswordViewModel.Error = request.Error;
                    return View(forgotPasswordViewModel);
                }
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            catch
            {
                return View();
            }

        }
        public ActionResult ResetPassword(string token)
        {
            return View(new ResetPasswordViewModel { Token = token});
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(resetPasswordViewModel);
                }
                ResetPasswordReponse request = await userService.ResetPasswordAsync(resetPasswordViewModel);

                if (request.HasError)
                {
                    resetPasswordViewModel.HasError = request!.HasError;
                    resetPasswordViewModel.Error = request.Error;
                    return View(resetPasswordViewModel);
                }
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            catch
            {
                return View();
            }

        }
        [Authorize]
        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit( string id)
        {

            var data = await userService.GetById(id , true);
            
            return View(data);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, UpdateUserViewModel updateUser)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(updateUser);
                }
                UpdateUserViewModel updateUserView = await userService.GetById("" ,true,updateUser.UserName);
                var result = await userService.UpdateUserAsync(id, updateUser);
                return RedirectToRoute(new { controller = "PasswordItem", action = "Index" });
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await userService.SignOutAsync();
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "User", action = "Login" });
        }

    }
}
