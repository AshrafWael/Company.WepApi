using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Department
    {
    //    [ForeignKey(nameof("Employee"))]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; }//forign Key
        public ICollection<Employee>? Employees { get; set; }


    }
}
