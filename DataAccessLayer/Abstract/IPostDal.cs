using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IPostDal:IGenericDal<Post>
    {
        List<Post> GetPostListWithUser();
        List<Post> GetPostListByUserId(int id);
    }
}
