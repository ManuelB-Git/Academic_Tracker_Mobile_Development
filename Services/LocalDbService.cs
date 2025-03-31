using Academic_Tracker_Mobile_Development.Models;
using SQLite;

namespace Academic_Tracker_Mobile_Development.Services
{
    public class LocalDbService
    {
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService(string db_path)
        {
            _connection = new SQLiteAsyncConnection(db_path);
            _connection.CreateTableAsync<Term>();
            _connection.CreateTableAsync<Course>();
            _connection.CreateTableAsync<Assessment>();
        }

        public SQLiteAsyncConnection GetConnection()
        {
            return _connection;
        }
    }
}
