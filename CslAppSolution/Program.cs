using LiteDB;
using Models;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace CslAppSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = GetTypeProprerty<Students, int>(x => x.Id);
            //using (var db = new LiteDatabase(@"MyData.db"))
            //{
            //    var model = db.GetCollection<Students>("students");
            //    model.EnsureIndex(x => x.Name);
            //    model.EnsureIndex(x => x.Active);

            //    var student1 = new Students();
            //    student1.Name = "Paul Stuners";
            //    student1.Active = true;

            //    var result = model.Insert(student1);

            //}
        }

        static object GetTypeProprerty<T, TKey>(Expression<Func<T, TKey>> obj)
            where T: class
        {
            LambdaExpression body = Expression.Lambda(obj).Body as LambdaExpression;
            MemberExpression name = body.Body as MemberExpression;
            string sssname = name.Member.Name;

            var ttttt = Type.GetTypeCode(body.GetType());
            
            var p01 = Expression.Parameter(typeof(TKey));

            T item = (T)Activator.CreateInstance(typeof(T));
            TKey itemKey = (TKey)Activator.CreateInstance(typeof(TKey));

            return null;
        }
    }
}
