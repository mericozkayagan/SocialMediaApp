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
    public class ProfileController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        UserValidator validator = new UserValidator();
        public IActionResult Index()
        {
            var user = User.Identity.Name;
            var loggedUser = um.GetList().Where(x => x.Email == user).Single();
            
            return View(loggedUser);
        }
        public IActionResult ChangeEmail(User p)
        {
            ValidationResult results = validator.Validate(p);
            
            if (results.IsValid)
            {
                um.Update(p);
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            
        }
        public IActionResult ChangePassword(User p)
        {

            ValidationResult results = validator.Validate(p);

            if (results.IsValid)
            {
                um.Update(p);
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        public IActionResult ChangeUsername(User p)
        {

            ValidationResult results = validator.Validate(p);

            if (results.IsValid)
            {
                um.Update(p);
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}
