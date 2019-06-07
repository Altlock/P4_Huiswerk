using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace week4.Database
{
    public interface IDBInterface
    {
        SQLiteConnection CreateConnection();
    }
}
