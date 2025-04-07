using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Academic_Tracker_Mobile_Development.Models
{
    public partial class Assessment : AcademicModel
    {
        [Required(ErrorMessage = "Assessment type is required")]
        public string Type { get; set; } = string.Empty;


        [Indexed]
        public int CourseId { get; set; }

        public bool NotificationsEnabled { get; set; }

    }
}
