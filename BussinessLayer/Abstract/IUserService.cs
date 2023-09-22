using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IUserService
    {
        public IList<TBLUser> GetAll(bool Siralama);
        public TBLUser GetById(int Id);
        public string Insert(TBLUser data);
        public string Update(TBLUser data);
        public string Delete(int Id);
    }
}
