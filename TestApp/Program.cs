using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int executeNonQuery = new Db().ExecuteNonQuery(@"INSERT INTO [dbo].[TestTable]
           ([Text])  VALUES('sssss')");

        }
    }
}
