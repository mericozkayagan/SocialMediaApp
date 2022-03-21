using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationDal());
        public IActionResult Index()
        {
            var values = nm.GetList().Where(x => x.NotificationStatus == true).OrderByDescending(x => x.NotificationDate).ToList();
            return View(values);
        }
    }
}
