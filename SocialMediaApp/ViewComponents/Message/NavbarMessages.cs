using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.ViewComponents.Message
{
    public class NavbarMessages:ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        UserManager um = new UserManager(new EfUserDal());
        public IViewComponentResult Invoke()
        {
              
                        
            var user = User.Identity.Name;            
            var messages = mm.GetListInbox(user);

            var count = mm.GetListInbox(user).Where(x => x.MessageStatus == false).Count();
            TempData["count"] = count;

            return View(messages);
        }        

    }
}
