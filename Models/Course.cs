using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Academic_Tracker_Mobile_Development.Models
{
    public class Course: AcademicModel
    {
        [Required(ErrorMessage ="Status is required")]
        public string Status { get; set; } = string.Empty;

        [Required(ErrorMessage = "Instructor name is required")]
        public string InstructorName { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string InstructorPhone { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string InstructorEmail { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;

        [Indexed]
        public int TermId { get; set; }

        public bool NotificationsEnabled { get; set; }



    }
}
