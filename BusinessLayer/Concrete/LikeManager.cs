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
    public class LikeManager : ILikeService
    {
        ILikeDal _likeDal;

        public LikeManager(ILikeDal likeDal)
        {
            _likeDal = likeDal;
        }

        public void Add(Like t)
        {
            _likeDal.Insert(t);
        }

        public void Delete(Like t)
        {
            throw new NotImplementedException();
        }

        public Like GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Like> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(Like t)
        {
            throw new NotImplementedException();
        }
    }
}
