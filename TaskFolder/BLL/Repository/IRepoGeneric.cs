using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Repository
{
   public interface IRepoGeneric<T> where T:class
    {
        IEnumerable<T> GetAll();

        T GetEntityOne(int id);

        //Task<T> Add(T t);

        //Task<T> Update(T t);

        void DeleteEnitity(int id);
    }
}
