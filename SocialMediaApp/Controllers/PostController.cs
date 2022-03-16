using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.Controllers
{
    public class PostController : Controller
    {
        PostManager pm = new PostManager(new EfPostDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreatePost()
        {
            List<SelectListItem> categoryvalue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString(),
                                                  }).ToList();
            ViewBag.cv = categoryvalue;
            return View();            
        }
        [HttpPost]
        public IActionResult CreatePost(Post p)
        {
            PostValidator validator = new PostValidator();
            p.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.LastUpdatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.PostStatus = true;
            p.UserId = 1;

            ValidationResult results = validator.Validate(p);
            if (results.IsValid)
            {
                pm.Add(p);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("Index","Home");
            
        }
        public IActionResult LikePost(int id)
        {
            var post = pm.GetById(id);            
            pm.Update(post);
            return RedirectToAction("Index", "Home");
        }
    }
}
