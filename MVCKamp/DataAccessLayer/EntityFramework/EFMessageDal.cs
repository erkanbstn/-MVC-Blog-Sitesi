using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFMessageDal : GenericRepository<Message>, IMessageDal
    {
        public List<Message> GetInBox(string mail)
        {
            using (var x = new Context())
            {
                return x.Messages.Where(b => b.ReceiverMail == mail).ToList();
            }
        }
        public List<Message> GetSendBox(string mail)
        {
            using (var x = new Context())
            {
                return x.Messages.Where(b => b.SenderMail == mail).ToList();
            }
        }
    }
}
