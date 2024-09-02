using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTasks.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal? Salary { get; set; }
        [ForeignKey("Department")]
        public int? DeptID { get; set; }
        public virtual Department Department { get; set; }
    }
}
