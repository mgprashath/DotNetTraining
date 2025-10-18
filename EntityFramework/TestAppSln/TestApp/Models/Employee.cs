using System.ComponentModel.DataAnnotations;

namespace TestApp.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string? City { get; set; }
        [Required]
        public string TelNum { get; set; } =string.Empty;
    }
}
