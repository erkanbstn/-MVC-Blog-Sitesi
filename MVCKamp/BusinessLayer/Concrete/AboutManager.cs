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
    public class AboutManager : IAboutService
    {
        IAboutDal _Aboutdal;
        //IRepository<About> _Aboutdal;  YAPILABİLİR VE DATAACCESSTEKİ ABSTRACT DOLMAYABİLİR.

        public AboutManager(IAboutDal Aboutdal)
        {
            _Aboutdal = Aboutdal;
        }

        public About IDGetir(int id)
        {
            return _Aboutdal.IDBul(n => n.AboutID == id);
        }

        public List<About> IDListele(int id)
        {
            return _Aboutdal.List(x => x.AboutID == id);
        }
        public List<About> Listele()
        {
            return _Aboutdal.List();
        }

        public void TEkle(About t)
        {
            _Aboutdal.Insert(t);
        }

        public void TGuncelle(About t)
        {
            _Aboutdal.Update(t);
        }

        public void TSil(About t)
        {
            _Aboutdal.Delete(t);
        }
    }
}
