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
    public class EFDraftDal : GenericRepository<Draft>, IDraftDal
    {
        public List<Draft> DraftList(string mail)
        {
            using (var c = new Context())
            {
                return c.Drafts.Where(b => b.DraftCreater == mail).ToList();
            }
        }
    }
}
