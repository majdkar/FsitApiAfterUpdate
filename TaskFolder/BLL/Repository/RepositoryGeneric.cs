using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Context;
using System.Threading.Tasks;
using DL.Model;

namespace BLL.Repository
{
    public class RepositoryGeneric<T> : IRepoGeneric<T> where T : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<T> entities;

        public RepositoryGeneric(ApplicationContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetEntityOne(int id)
        {
            return _context.Set<T>().Find(id);

        }

        public void DeleteEnitity(int id)
        {
            var _entity = _context.Set<T>().Find(id);
            if (_entity != null)
            {
                _context.Set<T>().Remove(_entity);
                _context.SaveChangesAsync();
            }
        }
    }
}
