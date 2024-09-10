using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTasks.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }
        public decimal? Salary { get; set; }
        [ForeignKey("Department")]
        public int? DeptID { get; set; }
        [Remote("CheckUniqueEmail", "Employee")]
        public string Email { get; set; }
        public bool Status { get; set; }
        public virtual Department? Department { get; set; }
    }
}
