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
    public class UserService : IUserService
    {
        private IRepositories<TBLUser> Repo;
        public UserService(IRepositories<TBLUser> Repo)
        {
            this.Repo = Repo;
        }

        public string Delete(int Id)
        {
            if (Repo.Delete(x=> x.Id == Id))
            {
                return "İşlem Başarıyla Tamamlandı.";
            }
            else
            {
                return "İşlem Başarısız Oldu.";
            }

        }

        public IList<TBLUser> GetAll(bool Siralama)
        {
            if (Siralama)
            {
                return Repo.GetAll().OrderBy(x=>x.Name).ToList();
            }
            else
            {
                return Repo.GetAll();
            }
        }

        public TBLUser GetById(int Id)
        {
            return Repo.GetById(x=> x.Id == Id);
        }

        public string Insert(TBLUser data)
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

        public string Update(TBLUser data)
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
