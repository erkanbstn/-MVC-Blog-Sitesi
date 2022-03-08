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
    public class WriterLoginManager : IWriterLoginService
    {
        IWriterDal _writerDal;
        public WriterLoginManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer WriterID(string mail)
        {
            return _writerDal.IDBul(n => n.WriterMail == mail);
        }

        public Writer YazarGetir(string username, string password)
        {
            return _writerDal.IDBul(n => n.WriterMail == username && n.WriterPassword == password);
        }
    }
}
