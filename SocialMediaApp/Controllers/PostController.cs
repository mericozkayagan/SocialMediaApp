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
        PostValidator validator = new PostValidator();
        public IActionResult Index(int id)
        {
            var values = pm.GetPostListByUserId(id);
            return View(values);
        }
        public IActionResult GetPostDetails(int id)
        {
            var value = pm.GetById(id);
            return View(value);
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
            return RedirectToAction("Index", "Home");

        }        

        [HttpGet]
        public IActionResult UpdatePost(int id)
        {
            List<SelectListItem> categoryvalue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString(),
                                                  }).ToList();
            ViewBag.c = categoryvalue;
            var post = pm.GetById(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult UpdatePost(Post p)
        {
            var post = pm.GetById(p.PostId);
            p.CreateDate = post.CreateDate;
            p.PostStatus = post.PostStatus;
            p.LastUpdatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.UserId = 1;
            
            ValidationResult results = validator.Validate(p);
            if (results.IsValid)
            {
                pm.Update(p);
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

        public IActionResult DeletePost(int id)
        {
            var post = pm.GetById(id);
            pm.Delete(post);
            return RedirectToAction("Index", "Profile");
        }
    }
}
