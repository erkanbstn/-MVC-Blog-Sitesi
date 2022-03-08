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
    public class DraftManager : IDraftService
    {
        IDraftDal _draftDal;

        public DraftManager(IDraftDal draftDal)
        {
            _draftDal = draftDal;
        }
        public List<Draft> DraftList(string mail)
        {
            return _draftDal.DraftList(mail);
        }

        public Draft IDGetir(int id)
        {
            return _draftDal.IDBul(b => b.DraftID == id);
        }

        public List<Draft> IDListele(int id)
        {
            return _draftDal.List(b => b.DraftID == id).ToList();
        }

        public List<Draft> Listele()
        {
            return _draftDal.List();
        }

        public void TEkle(Draft t)
        {
            _draftDal.Insert(t);
        }

        public void TGuncelle(Draft t)
        {
            _draftDal.Update(t);
        }

        public void TSil(Draft t)
        {
            _draftDal.Delete(t);
        }
    }
}
