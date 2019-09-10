using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using LiteDB;
namespace Repositories
{
    internal static class Utils
    {
        internal static string GetNameConfigurationType<T, TKey>(Expression<Func<T, TKey>> field)
        {
            LambdaExpression body = Expression.Lambda(field).Body as LambdaExpression;
            MemberExpression name = body.Body as MemberExpression;
            return name?.Member?.Name;
        }

        internal static string GetNameBsonField<T>(string propertyName)
        {
            T obj = Activator.CreateInstance<T>();
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
            BsonFieldAttribute bsonField = propertyInfo.GetCustomAttribute<BsonFieldAttribute>();
            return bsonField?.Name ?? propertyName;
        }

        internal static string GetName<T, TKey>(this Expression<Func<T, TKey>> field)
        {
            return GetNameBsonField<T>(GetNameConfigurationType(field));
        }
    }
}
