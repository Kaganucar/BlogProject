using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepositories<T> where T : class
    {
        public bool Insert(T data);
        public bool Update(T data);
        public bool Delete(Expression<Func<T,bool>> where);

        public IList<T> GetAll(Expression<Func<T,bool> >where = null);
        public T GetById(Expression<Func<T,bool>>where);

    }
}
