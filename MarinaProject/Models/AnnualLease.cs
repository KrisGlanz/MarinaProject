using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarinaProject.Models
{
    public class AnnualLease : Leases
    {
        public AnnualLease() { }

        [Required(ErrorMessage = "Please enter monthly pay rate.")]
        [Column(TypeName = "double")]
        public double monthlyPay { get; set; }

        [Required(ErrorMessage = "Please enter balance due.")]
        [Column(TypeName = "double")]
        public double balanceDue { get; set; }

    }
}
