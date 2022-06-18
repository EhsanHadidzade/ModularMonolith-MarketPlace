using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace _0_Framework.Infrastructure
{
    public class BaseRepository<Tkey, T> : IRepository<Tkey, T> where T : class
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add<T>(entity);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(Tkey id)
        {
            return _context.Find<T>(id);
        }
        public void RemoveById(Tkey id)
        {
            var entity = _context.Find<T>(id);
            _context.Remove(entity);
        }

        public bool IsExist(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public void Savechange()
        {
            _context.SaveChanges();
        }
    }
}
