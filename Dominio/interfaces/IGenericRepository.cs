using System.Linq.Expressions;
using Dominio.Entidades;

namespace Dominio.interfaces
{
    public interface IGenericRepository<T> where T : Base_entity
    {
            Task<T> GetByIdAsync(string id);
            Task<IEnumerable<T>> GetAllAsync();
            IEnumerable<T> Find(Expression<Func<T, bool>> expression);
            void Add(T entity);
            void AddRange(IEnumerable<T> entities);
            void Remove(T entity);
            void RemoveRange(IEnumerable<T> entities);
            void Update(T entity);           
    }
}

