using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class CategoriesService : ICategoriesService
    {
        private IRepositories<TBLCategories> Repo;
        public CategoriesService(IRepositories<TBLCategories> Repo)
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

        public IList<TBLCategories> GetAll()
        {
            return Repo.GetAll();
        }

        public TBLCategories GetById(int Id)
        {
            return Repo.GetById(x=> x.Id == Id);
        }

        public string Insert(TBLCategories data)
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

        public string Update(TBLCategories data)
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
