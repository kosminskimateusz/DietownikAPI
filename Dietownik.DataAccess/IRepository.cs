using System.Collections.Generic;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess
{

    public interface IRepository<T> where T : EntityBase
    {
        IEnumerable<T> GetaLL();

        T GetById(int id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}