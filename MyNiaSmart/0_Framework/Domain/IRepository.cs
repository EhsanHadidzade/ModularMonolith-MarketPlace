using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Domain
{
    public interface IRepository<Tkey,T>where T:class
    {
        T GetById(Tkey id);
        T FirstOrDefaultByQuery(Expression<Func<T, bool>> filter);
        List<T> GetAllByQuery(Expression<Func<T, bool>> filter);
        List<T> GetAll();
        void Create(T entity);
        void RemoveById(Tkey id);
        bool IsExist(Expression<Func<T,bool>> expression);
        void Savechange();

    }
}
