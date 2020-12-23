using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Database.Context;
using WebApp.Model;

namespace WebApp.Controllers
{
    public class QualitiesController : Controller
    {
        private readonly IQualityRepository _repository;
        private readonly IPersonRepository _personRepository;
        private readonly UserManager<Person> _userManager;
        private readonly SignInManager<Person> _signInManager;

        public QualitiesController(IQualityRepository repository, UserManager<Person> userManager, SignInManager<Person> signInManager, IPersonRepository personRepository)
        {
            _repository = repository;
            _userManager = userManager;
            _signInManager = signInManager;
            _personRepository = personRepository;
        }

        // GET: Qualities
        public IActionResult Index()
        {
            return View(_repository.GetAllQualities());
        }

        // GET: Qualities/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Quality quality, string id)
        {
            if (ModelState.IsValid)
            {
                var user = _personRepository.GetUserById(id);
                quality.Person = user;
                _repository.Create(quality);
                var url = "/People/Details/" + id;
                return Redirect(url);
                //return RedirectToAction("Details","People",id);
            }
            return View(quality);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, string foo)
        {
            var review = _repository.GetQualityById(id);
            _repository.Delete(review);
            var url = "/People/Details/" + foo;
            return Redirect(url);

        }    
    }
}
