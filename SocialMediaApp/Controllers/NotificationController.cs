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
    public class NotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationDal());
        NotificationValidator validator = new NotificationValidator();
        public IActionResult Index()
        {
            var values = nm.GetList().Where(x => x.NotificationStatus == true).OrderByDescending(x => x.NotificationDate).ToList();
            return View(values);
        }

        [HttpPost]
        public IActionResult AddNotification(Notification p)
        {           
            p.NotificationDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.NotificationStatus = true;

            ValidationResult result = validator.Validate(p);
            if (result.IsValid)
            {
                nm.Add(p);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return RedirectToAction("Index", "Dashboard");
            }
        }
    }
}
