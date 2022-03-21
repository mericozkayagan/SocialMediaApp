using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.Controllers
{

    public class RegisterController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        UserValidator uv = new UserValidator();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User p)
        {
            var passwordmatch = Request.Form["Textbox1"];
            p.UserStatus = true;
            p.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            ValidationResult validationResult = uv.Validate(p);
            if (validationResult.IsValid && p.Password == passwordmatch)
            {
                um.Add(p);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
    }
}

