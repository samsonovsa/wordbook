using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using WordBook.Models;
using WordBook.Services.DataServices.LocalDB;

namespace WordBook.Services.DataServices
{
    public class WordBookContext: IWordBookContext
    {
        IMongoDatabase _database;
        IGridFSBucket _gridFS;
        string nameDB = "MongoDB";
       

        public WordBookContext(IConnections connections)
        {
            string connectionString = connections.GetConnectionStringByName(nameDB);
            var connection = new MongoUrlBuilder(connectionString);
            MongoClient client = new MongoClient(connectionString);
            _database = client.GetDatabase(connection.DatabaseName);
            _gridFS = new GridFSBucket(_database);
        }

        public IMongoDatabase GetDb() => _database;

        public IGridFSBucket GetGridFS() => _gridFS;

        // получение изображения
        public async Task<byte[]> GetImage(string id)
        {
            return await _gridFS.DownloadAsBytesAsync(new ObjectId(id));
        }

        // сохранение изображения
        public async Task StoreImage(string id, Stream imageStream, string imageName)
        {
            // если ранее уже была прикреплена картинка, удаляем ее
            await _gridFS.DeleteAsync(new ObjectId(id));

            // сохраняем изображение
            ObjectId imageId = await _gridFS.UploadFromStreamAsync(imageName, imageStream);
        }
    }
}