using SQLite;

namespace Week_4
{
    public interface IDBInterface
    {
        SQLiteConnection CreateConnection();
    }
}