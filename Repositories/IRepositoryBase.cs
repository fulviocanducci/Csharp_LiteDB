using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repositories
{
    public interface IRepositoryBase<T>
    {
        T Insert(T model);
        bool Update(T model);
        T Find<TField>(TField id);
        bool Delete<TField>(TField id);
        int Delete(Expression<Func<T, bool>> where);
        IEnumerable<T> All();
        IEnumerable<T> All<TKey>(Expression<Func<T, TKey>> orderBy, QueryOrder queryOrder = QueryOrder.Ascending, int skip = 0, int limit = 2147483647);       
        IEnumerable<T> All<TKey>(Func<T, TKey> orderBy, Expression<Func<T, bool>> where, int skip = 0, int limit = 2147483647);
    }
}
