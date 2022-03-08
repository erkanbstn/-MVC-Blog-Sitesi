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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public Contact IDGetir(int id)
        {
            return _contactDal.IDBul(b => b.ContactID == id);

        }

        public List<Contact> IDListele(int id)
        {
            return _contactDal.List(b => b.ContactID == id);
        }

        public List<Contact> Listele()
        {
            return _contactDal.List();
        }

        public void TEkle(Contact t)
        {
            _contactDal.Insert(t);
        }

        public void TGuncelle(Contact t)
        {
            _contactDal.Update(t);
        }

        public void TSil(Contact t)
        {
            _contactDal.Delete(t);
        }
    }
}
