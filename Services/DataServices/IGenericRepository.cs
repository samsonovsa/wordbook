using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WordBook.Services.DataServices
{
    public interface IGenericRepository<T>
        where T: class, new()
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<IMongoQueryable<T>> QueryAsync { get; set; }

        Task<T> GetOneAsync(Expression<Func<T, bool>> expression);

        Task<T> FindOneAndUpdateAsync(Expression<Func<T, bool>> expression, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> option);

        Task UpdateOneAsync(Expression<Func<T, bool>> expression, UpdateDefinition<T> update);

        Task DeleteOneAsync(Expression<Func<T, bool>> expression);

        Task InsertManyAsync(IEnumerable<T> items);

        Task InsertOneAsync(T item);
    }
}
