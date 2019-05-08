using SQLite;

namespace Week2
{
    public interface IDBInterface
    {
        SQLiteConnection CreateConnection();
    }
}