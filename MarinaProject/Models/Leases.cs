using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MarinaProject.Models

{
    public class Leases
    {
        [Key]
        public int leaseId { get; set; }

        [Required(ErrorMessage = "")]
        [Column(TypeName = "double")]
        public double Amount { get; set; }
        
        [Required(ErrorMessage = "Please pick start date.")]
        [Column(TypeName = "Date")]
        public DateOnly startDate { get; set; }
        
        [Required(ErrorMessage = "Please enter end date.")]
        [Column(TypeName = "Date")]
        public DateOnly endDate { get; set; }





    }
}
