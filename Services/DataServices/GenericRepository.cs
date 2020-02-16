using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace WordBook.Services.DataServices
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class, new()
    {
        IMongoDatabase _database;
        IGridFSBucket _gridFS;
        string _entityName;

        public GenericRepository(IWordBookContext context)
        {
            _database = context.GetDb();
            _gridFS = context.GetGridFS();
            _entityName = GetNameOfEntity<T>();
        }

        protected IMongoCollection<T> Collection
        {
            get
            {
                return _database.GetCollection<T>(_entityName);
            }
            set
            {
                Collection = value;
            }
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _database.GetCollection<T>(_entityName)
               .Find(FilterDefinition<T>.Empty)
               .ToListAsync(); 
        }

        public Task<IMongoQueryable<T>> QueryAsync 
        { 
            get =>  Task<IMongoQueryable<T>>.Run(
                ()=> _database.GetCollection<T>(_entityName)
                .AsQueryable<T>()
                );
            set => QueryAsync = value;
        }

        public async Task DeleteOneAsync(Expression<Func<T, bool>> expression)
        {
           await  Collection.DeleteOneAsync(expression);
        }

        public async Task<T> FindOneAndUpdateAsync(Expression<Func<T, bool>> expression, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> option)
        {
            return await Collection.FindOneAndUpdateAsync(expression, update, option);
        }


        public async Task<T> GetOneAsync(Expression<Func<T, bool>> expression)
        {
            var collection = await _database
                .GetCollection<T>(_entityName)
                .FindAsync(expression);

           return await collection.SingleOrDefaultAsync();
        }

        public async Task InsertManyAsync(IEnumerable<T> items)
        {
            await Collection.InsertManyAsync(items);
        }

        public async Task InsertOneAsync(T item)
        {
            await Collection.InsertOneAsync(item);
        }

        public async Task UpdateOneAsync(Expression<Func<T, bool>> expression, UpdateDefinition<T> update)
        {
            await Collection.UpdateOneAsync(expression, update);
        }

        private string GetNameOfEntity<T>()
        {
            return typeof(T).Name+"s";
        }
    }
}