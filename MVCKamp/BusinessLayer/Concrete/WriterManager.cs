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
    public class WriterManager : IWriterService
    {

        IWriterDal _writerdal;

        public WriterManager(IWriterDal writerdal)
        {
            _writerdal = writerdal;
        }
        public Writer IDGetir(int id)
        {
            return _writerdal.IDBul(n => n.WriterID == id);
        }

        public List<Writer> IDListele(int id)
        {
            return _writerdal.List(n => n.WriterID == id);
        }

        public List<Writer> Listele()
        {
            return _writerdal.List();
        }

        public int MailBul(string mail)
        {
            return _writerdal.MailBul(mail);
        }

        public void TEkle(Writer t)
        {
             _writerdal.Insert(t);
        }

        public void TGuncelle(Writer t)
        {
            _writerdal.Update(t);
        }

        public void TSil(Writer t)
        {
            _writerdal.Delete(t);
        }
    }
}
