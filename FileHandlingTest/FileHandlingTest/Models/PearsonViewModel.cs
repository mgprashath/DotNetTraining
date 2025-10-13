using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace FileHandlingTest.Models
{
    public class PearsonViewModel
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [Range(18, 99, ErrorMessage = "Age must be between 18 and 99.")]
        public int? Age { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [RegularExpression("Male|Female", ErrorMessage = "The Gender must be either 'Male' or 'Female' only.")]
        public string Gender { get; set; }
    }
}
