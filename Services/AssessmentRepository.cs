using Academic_Tracker_Mobile_Development.Models;
using SQLite;


namespace Academic_Tracker_Mobile_Development.Services
{
    public  class AssessmentRepository
    {
        private readonly SQLiteAsyncConnection _connection;

        public AssessmentRepository()
        {
            _connection = LocalDbService.Database;


        }


        public async Task<List<Assessment>> GetAssessments(int CourseID) => await _connection.Table<Assessment>().Where(a => a.CourseId == CourseID).ToListAsync();

        public async Task<int> SaveAssessment(Assessment assessment)

        {
            if(assessment.Id != 0)
            {
                return await _connection.UpdateAsync(assessment);
            }
            else
            {
                return await _connection.InsertAsync(assessment);
            }
        }

        public async Task<int> DeleteAssessment(Assessment assessment) => await _connection.DeleteAsync(assessment);
        

    }
}
