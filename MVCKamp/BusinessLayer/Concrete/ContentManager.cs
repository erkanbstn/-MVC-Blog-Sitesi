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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;
        //IRepository<Category> _categorydal;  YAPILABİLİR VE DATAACCESSTEKİ ABSTRACT DOLMAYABİLİR.

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public List<Content> ContentBul(string hece)
        {
            return _contentDal.List(b => b.ContentValue.Contains(hece));
        }

        public List<Content> HeadingContent(int id)
        {
            return _contentDal.List(b => b.HeadingID == id);
        }

        public Content IDGetir(int id)
        {
            return _contentDal.IDBul(n => n.ContentID == id);
        }

        public List<Content> IDListele(int id)
        {
            return _contentDal.List(x => x.HeadingID == id);
        }
        public List<Content> Listele()
        {
            return _contentDal.List();
        }

        public void TEkle(Content t)
        {
            _contentDal.Insert(t);
        }

        public void TGuncelle(Content t)
        {
            _contentDal.Update(t);
        }

        public void TSil(Content t)
        {
            _contentDal.Delete(t);
        }

        public List<Content> WriterContent(int id)
        {
            return _contentDal.List(b => b.WriterID == id);
        }
    }
}
