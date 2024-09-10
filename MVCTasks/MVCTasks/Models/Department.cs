using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTasks.Models
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int ID { get; set; }
        public string DeptName { get; set; }
        [Range(50, 100)]
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public virtual List<Employee>? Employees { get; set; }
    }
}
