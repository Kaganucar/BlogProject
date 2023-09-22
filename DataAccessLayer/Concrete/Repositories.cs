using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Repositories<T> : IRepositories<T> where T : class
    {
        public bool Delete(Expression<Func<T, bool>> where)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    db.Set<T>().Remove(GetById(where));
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public IList<T> GetAll(Expression<Func<T, bool>> where = null)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                if (where is not null)
                {
                    return db.Set<T>().AsNoTracking().Where(where).ToList();
                }
                else
                {
                    return db.Set<T>().AsNoTracking().ToList();
                }
            }
        }

        public T GetById(Expression<Func<T, bool>> where)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Set<T>().AsNoTracking().Where(where).FirstOrDefault();
            }
        }

        public bool Insert(T data)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    db.Set<T>().Add(data);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public bool Update(T data)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    db.Set<T>().Update(data);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }
    }
}
