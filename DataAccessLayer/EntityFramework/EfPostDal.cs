using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfPostDal : GenericRepository<Post>, IPostDal
    {
        public List<Post> GetPostListWithUser()
        {
            using var c = new Context();
            return c.Posts.Include(x => x.User).Include(x=>x.Category).ToList();
        }
        public List<Post> GetPostListByUserId(int id)
        {
            using var c = new Context();
            return c.Posts.Include(x => x.User).Where(x=>x.UserId==id).ToList();
        }        
        public Post GetById(int id)
        {
            using var c = new Context();
            return c.Posts.Include(x => x.User).Include(x => x.Category).Where(x => x.PostId == id).Single();
        }
    }
}
