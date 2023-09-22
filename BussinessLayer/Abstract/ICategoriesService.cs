using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface ICategoriesService
    {
        public IList<TBLCategories> GetAll();
        public TBLCategories GetById(int Id);
        public string Insert(TBLCategories data);
        public string Update(TBLCategories data);
        public string Delete(int Id);
    }
}
