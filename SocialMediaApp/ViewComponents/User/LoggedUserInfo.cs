using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.ViewComponents.User
{
    public class LoggedUserInfo:ViewComponent
    {
        UserManager um = new UserManager(new EfUserDal());
        public IViewComponentResult Invoke()
        {
            var user = User.Identity.Name;
            var loggedUser = um.GetList().Where(x => x.Email == user).Single();
            return View(loggedUser);
        }
    }
}
