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

        public List<Message> GetInBox(string mail)
        {
            return _messageDal.List(b=>b.ReceiverMail==mail);
        }

        public List<Message> GetSendBox(string mail)
        {
            return _messageDal.List(b => b.SenderMail == mail);
        }

        public Message IDGetir(int id)
        {
            return _messageDal.IDBul(b => b.MessageID == id);
        }

        public List<Message> IDListele(int id)
        {
            return _messageDal.List(b => b.MessageID == id);
        }

        public List<Message> Listele()
        {
            return _messageDal.List();
        }
        public void TEkle(Message t)
        {
            _messageDal.Insert(t);
        }

        public void TGuncelle(Message t)
        {
            _messageDal.Update(t);
        }

        public void TSil(Message t)
        {
            _messageDal.Delete(t);
        }
    }
}
