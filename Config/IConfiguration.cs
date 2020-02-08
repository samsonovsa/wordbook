using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordBook.Config
{
    public interface IConfiguration
    {
        string GetConnectionString(string name);
    }
}
