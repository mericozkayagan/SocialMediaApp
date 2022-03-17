using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.ViewComponents.Like
{
    public class GetTopLiked3Post:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            PostManager pm = new PostManager(new EfPostDal());
            var values = pm.GetMostLikedThreePost();
            return View(values);
        }
    }
}
