using Academic_Tracker_Mobile_Development.Models;
using SQLite;

namespace Academic_Tracker_Mobile_Development.Services
{
    public class LocalDbService
    {
        private static SQLiteAsyncConnection? _database;

        public static async Task InitAsync(string dbPath)
        {
            if (_database != null)
                return;

            _database = new SQLiteAsyncConnection(dbPath);
            await _database.CreateTableAsync<Term>();
            await _database.CreateTableAsync<Course>();
            await _database.CreateTableAsync<Assessment>();
        }

        public static SQLiteAsyncConnection Database => _database ?? throw new InvalidOperationException("Database not initialized. Call InitAsync first.");

    }
}