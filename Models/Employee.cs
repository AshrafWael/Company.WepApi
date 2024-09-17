using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Employee
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public Department? Department { get; set; }
      
    }
}
