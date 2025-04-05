using GestorPassword.Core.Application.Interfaces.Services;
using GestorPassword.Core.Application.ViewModel.PasswordItem;
using GestorPassword.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GestorPassword.Controllers
{
    [Authorize]
    public class PasswordItemController : Controller
    {
        private readonly IPasswordItemServices passwordItemServices;
        private readonly UserManager<ApplitationUser> userManager;

        public PasswordItemController(IPasswordItemServices passwordItemServices, UserManager<ApplitationUser> userManager)
        {
            this.passwordItemServices = passwordItemServices;
            this.userManager = userManager;
        }
        // GET: PasswordItemController
        public async Task<ActionResult> Index()
        {
            var result = await passwordItemServices.GetAllViewModel();
            var currentUser = await userManager.GetUserAsync(User);
            return View(result.Where(p => p.UserId == currentUser!.Id));
        }

        // GET: PasswordItemController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await passwordItemServices.GetByIdSaveViewModel(id);
            return View(result);
        }

        // GET: PasswordItemController/Create
        public async Task<ActionResult> Create()
        {
            var currentUser = await userManager.GetUserAsync(User);

            return View(new SavePasswordItemViewModel { UserId = currentUser!.Id});
        }

        // POST: PasswordItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SavePasswordItemViewModel collection)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(collection);
                }

                await passwordItemServices.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PasswordItemController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await passwordItemServices.GetByIdSaveViewModel(id);
            return View(result);
        }

        // POST: PasswordItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SavePasswordItemViewModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }

                await passwordItemServices.Update(collection,id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PasswordItemController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var result = await passwordItemServices.GetByIdSaveViewModel(id);
            return View(result);
        }

        // POST: PasswordItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await passwordItemServices.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
