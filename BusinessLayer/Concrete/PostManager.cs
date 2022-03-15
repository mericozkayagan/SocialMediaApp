using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PostManager : IPostService
    {
        IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public void Add(Post t)
        {
            _postDal.Insert(t);
        }

        public void Delete(Post t)
        {
            _postDal.Delete(t);
        }

        public Post GetById(int id)
        {
            return _postDal.GetById(id);
        }

        public List<Post> GetList()
        {
            return _postDal.GetListAll();
        }

        public void Update(Post t)
        {
            _postDal.Update(t);
        }
    }
}
