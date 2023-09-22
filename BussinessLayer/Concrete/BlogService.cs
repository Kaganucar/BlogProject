using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class BlogService : IBlogService
    {
        private IRepositories<TBLBlog> Repo;
        public BlogService(IRepositories<TBLBlog> Repo) 
        { 
            this.Repo = Repo;
        }
        public string Delete(int Id)
        {
            if (Repo.Delete(x => x.Id == Id))
            {
                return "İşlem Başarıyla Tamamlandı.";
            }
            else
            {
                return "İşlem Başarısız Oldu.";
            }
        }

        public IList<TBLBlog> GetAll()
        {
            return Repo.GetAll();
        }

        public TBLBlog GetById(int Id)
        {
            return Repo.GetById(x => x.Id == Id);
        }

        public string Insert(TBLBlog data)
        {
            if (Repo.Insert(data))
            {
                return "İşlem Başarıyla Tamamlandı.";
            }
            else
            {
                return "İşlem Başarısız Oldu.";
            }
        }

        public string Update(TBLBlog data)
        {
            if (Repo.Update(data))
            {
                return "İşlem Başarıyla Tamamlandı.";
            }
            else
            {
                return "İşlem Başarısız Oldu.";
            }
        }
    }
}
