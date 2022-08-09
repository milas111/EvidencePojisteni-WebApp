using EvidencePojisteni.Classes;
using EvidencePojisteni.Data;
using EvidencePojisteni.Extensions;
using EvidencePojisteni.Models.Account;
using EvidencePojisteni.Models.Insureds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EvidencePojisteni.Controllers
{
    [Authorize]
    [ExceptionsToMessageFilter]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var model = new Register();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                if (await userManager.FindByEmailAsync(model.Email) == null)
                {
                    var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                    var result = await userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await CreateInsured(model, user.Id);
                        await signInManager.SignInAsync(user, isPersistent: false);
                        this.AddFlashMessage(new FlashMessage("Registrace proběhla úspěšně", FlashMessageType.Success));
                        return string.IsNullOrEmpty(returnUrl)
                            ? RedirectToAction("Index", "Home")
                            : RedirectToLocal(returnUrl);
                    }

                    AddErrors(result);
                }

                AddErrors(IdentityResult.Failed(new IdentityError() { Description = $"Email {model.Email} je již registrován" }));
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
                return View(model);

            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                this.AddFlashMessage(new FlashMessage("Přihlášení proběhlo úspěšně", FlashMessageType.Success));
                return RedirectToLocal(returnUrl);
            }

            ModelState.AddModelError(string.Empty, "Neplatné přihlašovací údaje");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await userManager.GetUserAsync(User)
                ?? throw new ApplicationException($"Nepodařilo se načíst uživatele s ID {userManager.GetUserId(User)}.");

            var model = new ChangePassword();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePassword model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await userManager.GetUserAsync(User)
                ?? throw new ApplicationException($"Nepodařilo se načíst uživatele s ID: {userManager.GetUserId(User)}.");

            var changePasswordResult = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (!changePasswordResult.Succeeded)
            {
                AddErrors(changePasswordResult);
                return View(model);
            }

            await signInManager.SignInAsync(user, isPersistent: false);

            this.AddFlashMessage(new FlashMessage("Změna hesla proběhla úspěšně", FlashMessageType.Success));

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit()
        {
            var model = new InsuredBase();
            Insured insured = _context.Insured.Where(x => x.UserId == userManager.FindByNameAsync(User.Identity.Name).Result.Id).FirstOrDefault();
            model.FirstName = insured.FirstName;
            model.SurName = insured.SurName;
            model.Email = insured.Email;
            model.City = insured.City;
            model.Street = insured.Street;
            model.Phone = insured.Phone;
            model.Zip = insured.Zip;
            model.Gender = insured.Gender;
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(InsuredBase model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = userManager.FindByNameAsync(User.Identity.Name).Result;
                EditInsured(model, user.Id);
                this.AddFlashMessage(new FlashMessage("Údaje byly úspěšně uloženy", FlashMessageType.Success));

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            this.AddFlashMessage(new FlashMessage("Odhlášení proběhlo úspěšně", FlashMessageType.Success));
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        #region Privates
        private IActionResult RedirectToLocal(string returnUrl)
        {
            return Url.IsLocalUrl(returnUrl)
                ? Redirect(returnUrl)
                : (IActionResult)RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private async Task<Insured> CreateInsured(InsuredBase model, string userId)
        {
            Insured insured = new Insured
            {
                UserId = userId,
                Email = model.Email,
                FirstName = model.FirstName,
                SurName = model.SurName,
                City = model.City,
                Street = model.Street,
                Phone = model.Phone,
                Zip = model.Zip,
                Gender = model.Gender,
            };
            _context.Add(insured);
            await _context.SaveChangesAsync();
            return insured;
        }

        private async Task<Insured> EditInsured(InsuredBase model, string userId)
        {
            Insured insured = _context.Insured.Where(x => x.UserId == userId).FirstOrDefault();

            insured.UserId = userId;
            insured.Email = model.Email;
            insured.FirstName = model.FirstName;
            insured.SurName = model.SurName;
            insured.City = model.City;
            insured.Street = model.Street;
            insured.Phone = model.Phone;
            insured.Zip = model.Zip;
            insured.Gender = model.Gender;

            _context.Update(insured);
            await _context.SaveChangesAsync();
            return insured;
        }
        #endregion
    }
}
