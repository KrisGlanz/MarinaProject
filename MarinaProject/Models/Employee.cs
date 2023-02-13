using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarinaProject.Models
{
    public class Employee
    {
        [Key]
        public int employeeID { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [Column(TypeName = "nvarchar(100)")]
        public string? empName { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        [Column(TypeName = "nvarchar(50)")]
        public string? empAddress { get; set; }

        [Required(ErrorMessage = "Please enter phone number.")]
        [Column(TypeName = "int")]
        public int empPhoneNum { get; set; }

        [Required(ErrorMessage = "Please enter your pay amount.")]
        [Column(TypeName = "int")]
        public int empPay { get; set; }

        [Required(ErrorMessage = "Please enter your job.")]
        [Column(TypeName = "varchar")]
        public string? empJob { get; set; }
    }

}
