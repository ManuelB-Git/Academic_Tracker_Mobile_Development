

namespace Academic_Tracker_Mobile_Development.Models
{
    public abstract class AcademicModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public virtual bool ValidateDates()
        {
            if (EndDate <= StartDate)
            {
                return false;
            }
            return true;
        }

        public virtual string DisplayDates()
        {
            return $"{Title} ({StartDate:MMM yyyy} - {EndDate:MMM yyyy})";
        }
    }
}
