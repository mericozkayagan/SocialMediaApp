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
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        UserManager um = new UserManager(new EfUserDal());
        CommentValidator validator = new CommentValidator();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddComment(Comment p,int id)
        {
            var user = User.Identity.Name;
            var loggedUser = um.GetList().Where(x => x.Email == user).Single();
            p.PostId = id;
            p.UserId = loggedUser.UserId;
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            ValidationResult result = validator.Validate(p);
            if (result.IsValid)
            {
                cm.Add(p);
                return RedirectToAction("GetPostDetails/" + id, "Post");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            
        }
    }
}
