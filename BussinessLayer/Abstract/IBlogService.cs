using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IBlogService
    {
        public IList<TBLBlog> GetAll();
        public TBLBlog GetById(int Id);
        public string Insert(TBLBlog data);
        public string Update(TBLBlog data);
        public string Delete(int Id);
    }
}
