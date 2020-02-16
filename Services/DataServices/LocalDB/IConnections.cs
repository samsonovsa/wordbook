using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordBook.Services.DataServices.LocalDB
{
    public interface IConnections
    {
        string GetConnectionStringByName(string name);
    }
}