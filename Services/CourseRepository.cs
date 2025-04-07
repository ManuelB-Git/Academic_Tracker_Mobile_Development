using Academic_Tracker_Mobile_Development.Models;
using SQLite;

namespace Academic_Tracker_Mobile_Development.Services
{
    public class CourseRepository
    {
        private readonly SQLiteAsyncConnection _connection;
        public CourseRepository()
        {
            _connection = LocalDbService.Database;

        }


        public async Task<List<Course>> GetCourses(int termID) => await _connection.Table<Course>().Where(c => c.TermId == termID).ToListAsync();

        public async Task<Course> GetCourseById(int courseID) => await _connection.Table<Course>().Where(c => c.Id == courseID).FirstOrDefaultAsync();

        public async Task<int> SaveCourse(Course course)
        {
            if (course.Id != 0)
            {
                return await _connection.UpdateAsync(course);
            }
            else
            {
                return await _connection.InsertAsync(course);
            }
        }

        public async Task<int> DeleteCourse(Course course)
        {
            ArgumentNullException.ThrowIfNull(course);

             await _connection.RunInTransactionAsync(tran =>
            {
                 tran.Table<Assessment>().Where(a => a.CourseId == course.Id).Delete();
                 tran.Delete(course);
            });
            return 0;

        }

    }
}
