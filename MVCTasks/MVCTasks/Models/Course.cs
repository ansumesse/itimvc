using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCTasks.Models
{
    public class Course
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(50, 100)]
        public int Degree { get; set; }
        [DefaultValue(true)]
        public bool Status { get; set; }
    }
}
