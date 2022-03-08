using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService : IGenericService<Content>
    {
        List<Content> WriterContent(int id);
        List<Content> HeadingContent(int id);
        List<Content> ContentBul(string hece);
    }
}
