using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.ViewComponents.Category
{
    public class GetCategoryList:ViewComponent
    {       
        public IViewComponentResult Invoke()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryDal());
            var values = cm.GetList();         
            return View(values);
        }
    }
}
