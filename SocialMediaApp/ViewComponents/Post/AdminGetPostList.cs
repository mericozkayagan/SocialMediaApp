using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.ViewComponents.Post
{
    public class AdminGetPostList:ViewComponent
    {
        PostManager pm = new PostManager(new EfPostDal());
        public IViewComponentResult Invoke()
        {
            var values = pm.GetPostListWithUser().OrderByDescending(x => x.LastUpdatedDate).Take(5).ToList();
            return View(values);
        }
    }
}
