using System;
namespace ExpressionDemo
{
    public class MyDatabase : IDatabase
    {
        public async Task<T> FindEntity<T>(Object keyvalue) where T : class
        {


        }
    }
}