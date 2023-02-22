using System.ComponentModel.DataAnnotations;

namespace Employee_DBLayer.Model
{
    public class Employee

    {
        [Key]
        public int EmployeeId { get; set; }
        public  string? EmployeeName { get;set; }
        public int EmployeeAge { get; set; }
        public string? EmployeeSalary { get;set; }

    }
}