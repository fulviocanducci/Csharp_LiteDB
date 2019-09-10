using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    {
        public LiteDatabase LiteDatabase { get; }
        public LiteCollection<T> Collection { get; }
        public RepositoryBase(LiteDatabase liteDatabase)
        {
            LiteDatabase = liteDatabase;             
            Collection = LiteDatabase.GetCollection<T>(typeof(T).Name.ToLower());            
        }

        public T Insert(T model)
        {
            Collection.Insert(model);            
            return model;
        }

        public bool Update(T model)
        {
            return Collection.Update(model); 
        }

        public T Find<TField>(TField id)
        { 
            return Collection.FindById(new BsonValue(id));
        }

        public bool Delete<TField>(TField id)
        {
            return Collection.Delete(new BsonValue(id));
        }

        public int Delete(Expression<Func<T, bool>> where)
        {
            return Collection.Delete(where);
        }

        public IEnumerable<T> All()
        {
            return Collection.Find(Query.All());
        }

        public IEnumerable<T> All<TKey>(Expression<Func<T, TKey>> orderBy, QueryOrder queryOrder = QueryOrder.Ascending, int skip = 0, int limit = 2147483647)
        {
            Enum.
            return Collection.Find(Query.All(orderBy.GetName(), (int)queryOrder), skip, limit);
        }

        public IEnumerable<T> All<TKey>(Func<T, TKey> orderBy, Expression<Func<T, bool>> where, int skip = 0, int limit = 2147483647)
        {
            return Collection.Find(where, skip, limit).OrderBy(orderBy).AsEnumerable();
        }
    }
}
