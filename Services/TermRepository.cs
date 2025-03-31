using Academic_Tracker_Mobile_Development.Models;
using SQLite;

namespace Academic_Tracker_Mobile_Development.Services
{
    public class TermRepository
    {
        private readonly SQLiteAsyncConnection _connection;
        public TermRepository()
        {
            _connection = App.LocalDbService.GetConnection();
        }


        public async Task<List<Term>> GetAllTerms() => await _connection.Table<Term>().ToListAsync();

        public async Task<Term> GetTermById(int termId) => await _connection.Table<Term>().Where(t => t.Id == termId).FirstOrDefaultAsync();
        

        public async Task<int> SaveTerm(Term term)
        {
            if (term.Id != 0)
            {
                return await _connection.UpdateAsync(term);
            }
            else
            {
                return await _connection.InsertAsync(term);
            }
        }

        public async Task<int> DeleteTerm(Term term)
        {
            ArgumentNullException.ThrowIfNull(term);

            int result = 0;
            await _connection.RunInTransactionAsync(tran => 
            {
                var courses = tran.Table<Course>().Where(c => c.TermId == term.Id).ToList();

                foreach (var course in courses)
                {
                    var assessments = tran.Table<Assessment>().Where(a => a.CourseId == course.Id).ToList();
                    foreach (var assessment in assessments)
                    {
                        tran.Delete(assessment);
                    }

                    tran.Delete(course);
                }

                result = tran.Delete(term);
            });

            return result;
        }



    }
}
