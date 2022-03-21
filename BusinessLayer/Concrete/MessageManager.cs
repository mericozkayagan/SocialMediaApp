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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message t)
        {
            _messageDal.Insert(t);
        }

        public void Delete(Message t)
        {
            _messageDal.Delete(t);
        }

        public Message GetById(int id)
        {
            return _messageDal.GetById(id);
        }        

        public List<Message> GetList()
        {
            return _messageDal.GetListAll();
        }

        public List<Message> GetListInbox(string p)
        {
            return _messageDal.GetListAll().Where(x => x.Reciever == p).ToList();
        }

        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.GetListAll().Where(x => x.Sender == p).ToList();
        }

        public void Update(Message t)
        {
            _messageDal.Update(t);
        }
    }
}
