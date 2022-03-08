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
    public class HeadingManager : IHeadingService
    {

        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public List<Heading> GetWriterHeading(int id)
        {
            return _headingDal.List(b => b.WriterID == id);
        }

        public Heading IDGetir(int id)
        {
            return _headingDal.IDBul(b => b.HeadingID == id);
        }

        public List<Heading> IDListele(int id)
        {
            return _headingDal.List(b => b.HeadingID == id);
        }

        public List<Heading> Listele()
        {
            return _headingDal.List();
        }

        public void TEkle(Heading t)
        {
            _headingDal.Insert(t);
        }

        public void TGuncelle(Heading t)
        {
            _headingDal.Update(t);
        }

        public void TSil(Heading t)
        {
            _headingDal.Update(t);
        }
    }
}
