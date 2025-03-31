using SQLite;
using System.ComponentModel.DataAnnotations;


namespace Academic_Tracker_Mobile_Development.Models
{
    public abstract class AcademicModel
    {
        //Id
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }


        //Title
        [Required(ErrorMessage = "Term title is required")]
        public string Title {  get; set; } = string.Empty;


        //Dates
        [Required(ErrorMessage = "Term Start Date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Term End Date is required")]
        public DateTime EndDate { get; set; }



        //Methods
        public virtual bool ValidateDates()
        {
            if (EndDate <= StartDate)
            {
                return false;
            }
            return true;
        }

        public virtual string DisplayNameAndDate()
        {
            return $"{Title} ({StartDate:MMM yyyy} - {EndDate:MMM yyyy})";
        }
    }
}
