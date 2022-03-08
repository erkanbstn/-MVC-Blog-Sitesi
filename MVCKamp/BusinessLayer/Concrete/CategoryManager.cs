using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{

    public class CategoryManager : ICategoryService
    {
        #region
        //GenericRepository<Category> rep = new GenericRepository<Category>();

        //public List<Category> KategorileriListeleBLL()
        //{
        //    return rep.List();
        //}

        //public void KategoriEkleBLL(Category c)
        //{
        //    if (c.CategoryName.Length <= 3 || c.CategoryName.Length > 51 || c.CategoryName == "" || c.CategoryDescription == "")
        //    {

        //    }
        //    else
        //    {
        //        rep.Insert(c);
        //    }
        //}
        // Kalıtımsız Bu da çalışır
        #endregion

        ICategoryDal _categorydal;
        //IRepository<Category> _categorydal;  YAPILABİLİR VE DATAACCESSTEKİ ABSTRACT DOLMAYABİLİR.

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        public Category IDGetir(int id)
        {
            return _categorydal.IDBul(n => n.CategoryID == id);
        }

        public List<Category> IDListele(int id)
        {
            return _categorydal.List(x => x.CategoryID == id);
        }
        public List<Category> Listele()
        {
            return _categorydal.List();
        }

        public void TEkle(Category t)
        {
            _categorydal.Insert(t);
        }

        public void TGuncelle(Category t)
        {
            _categorydal.Update(t);
        }

        public void TSil(Category t)
        {
            _categorydal.Delete(t);
        }
    }
}
