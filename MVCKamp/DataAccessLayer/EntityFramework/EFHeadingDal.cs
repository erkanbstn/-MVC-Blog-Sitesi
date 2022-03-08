﻿using DataAccessLayer.Abstract;
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
    public class EFHeadingDal : GenericRepository<Heading>, IHeadingDal
    {
        public List<Heading> GetWriterHeading(int id)
        {
            using (var c = new Context())
            {
                return c.Headings.Where(b => b.WriterID == id).ToList();
            }
        }
    }
}
