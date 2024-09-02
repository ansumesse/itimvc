using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTasks.Models
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string DeptName { get; set; }
        public int Capacity { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
