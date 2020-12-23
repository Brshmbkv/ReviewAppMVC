using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Database.Context;
using WebApp.Model;
using WebApp.ViewModel;


namespace WebApp.Controllers
{
    public class PeopleController : Controller
    {
        private readonly UserManager<Person> _userManager;
        private readonly SignInManager<Person> _signInManager;
        private readonly IPersonRepository _personRepository;
        private readonly IQualityRepository _qualityRepository;
        public PeopleController(UserManager<Person> userManager, SignInManager<Person> signInManager, IPersonRepository personRepository, IQualityRepository qualityRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _personRepository = personRepository;
            _qualityRepository = qualityRepository;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel person)
        {
            if (ModelState.IsValid)
            {
                Person user = new Person {
                    Name = person.Name,
                    Surname = person.Surname,
                    Email = person.Email,
                    Gender = (Model.Gender)person.Gender,
                    DateTimeOfBirth = person.DateTimeOfBirth,
                    UserName = person.Email
                };

                var result = await _userManager.CreateAsync(user, person.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View("Register",person);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login and (or) password");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var user = _personRepository.GetUserById(id);
            var qualities = _qualityRepository.GetAllQualitiesByUserId(id);
            ReviewsViewModel rvm = new ReviewsViewModel
            {
                Person = user,
                Qualities = qualities
            };
            return View(rvm);
        }
    }
}
