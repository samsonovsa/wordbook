using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WordBook.Models;

namespace WordBook.Services.DataServices
{
    public interface IWordBookContext
    {
        IMongoDatabase GetDb();
        IGridFSBucket GetGridFS();
        Task<byte[]> GetImage(string id);
        Task StoreImage(string id, Stream imageStream, string imageName);
    }
}