using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class AppSettings
    {
        public static string ConnectionString()
        {
            string constring = "Server=localhost;Database=mydb;Uid=root;Pwd=''";

            return constring;
        }
    }
}
