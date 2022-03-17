using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.Controllers
{
    public class LikeController : Controller
    {
        LikeManager lm = new LikeManager(new EfLikeDal());
        [HttpPost]
        public PartialViewResult LikePost(int id)
        {            
            var like = new Like() { PostId = id, UserId = 1 };
            lm.Add(like);
            return PartialView();
        }
    }
}
