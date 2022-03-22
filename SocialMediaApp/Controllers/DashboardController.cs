using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.Controllers
{
    public class DashboardController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        PostManager pm = new PostManager(new EfPostDal());
        UserManager um = new UserManager(new EfUserDal());
        LikeManager lm = new LikeManager(new EfLikeDal());
        
        public IActionResult Index()
        {
            ViewBag.categoryCount = cm.GetList().Count();
            ViewBag.postCount = pm.GetList().Count();
            ViewBag.userCount = um.GetList().Count();
            ViewBag.likeCount = lm.GetList().Count();
            return View();
        }
    }
}
