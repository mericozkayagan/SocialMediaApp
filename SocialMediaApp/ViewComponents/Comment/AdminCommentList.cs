using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.ViewComponents.Comment
{
    public class AdminCommentList:ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke()
        {
            var values = cm.GetCommentListWithUser().OrderByDescending(x=>x.CommentDate).Take(10).ToList();
            return View(values);
        }
    }
}
