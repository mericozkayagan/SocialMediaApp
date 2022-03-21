using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.ViewComponents.Notification
{
    public class NavbarNotification:ViewComponent
    {
        NotificationManager nm = new NotificationManager(new EfNotificationDal());
        public IViewComponentResult Invoke()
        {
            var values = nm.GetList().Where(x => x.NotificationStatus == true).OrderByDescending(x => x.NotificationDate).Take(5).ToList();
            return View(values);
        }
    }
}
