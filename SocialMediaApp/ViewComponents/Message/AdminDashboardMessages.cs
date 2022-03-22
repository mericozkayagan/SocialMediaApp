using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.ViewComponents.Message
{
    public class AdminDashboardMessages:ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        AdminManager am = new AdminManager(new EfAdminDal());
        public IViewComponentResult Invoke()
        {
            var user = User.Identity.Name;
            var loggedUser = am.GetList().Where(x => x.Email == user).Single();
            
            var values = mm.GetListInbox(user).OrderByDescending(x=>x.MessageDate).Take(7).ToList(); 
            var count = mm.GetListInbox(user).Where(x => x.MessageStatus == false).Count();
            TempData["count"] = count;
            return View(values);
        }
    }
}
