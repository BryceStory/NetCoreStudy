using System.Linq.Expressions;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace ExpressionDemo
{
    public interface IDatabase
    {
        Task<T> FindEntity<T>(Object keyvalue) where T : class;
        Task<T> FindEntity<T>(Expression<Func<T, bool>> condition) where T : class, new();
    }
}