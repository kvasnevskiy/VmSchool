using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VmSchool.DAL.Interfaces
{
    public interface IDatabaseRepository<T> where T : class
    {
        IEnumerable<T> ReadAll();
        T Read(int id);
        IEnumerable<T> ReadByExpression(Expression<Func<T, bool>> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}