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
        UserManager um = new UserManager(new EfUserDal());
        [HttpPost]
        public PartialViewResult LikePost(int id)
        {
            var user = User.Identity.Name;
            var loggedUser = um.GetList().Where(x => x.Email == user).Single();
            var like = new Like() { PostId = id, UserId = loggedUser.UserId };
            lm.Add(like);
            return PartialView();
        }
    }
}
