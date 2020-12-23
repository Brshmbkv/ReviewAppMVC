using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Model;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly UserManager<Person> _userManager;
        private readonly SignInManager<Person> _signInManager;

        public HomeController(IPersonRepository repository, UserManager<Person> userManager, SignInManager<Person> signInManager)
        {
            _personRepository = repository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            var users = _personRepository.GetAllUsersExceptCurrent(_userManager.GetUserId(User));
            return View(users);
        }

    }
}
