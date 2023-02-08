using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarinaProject.Models
{
    public class DailyLease : Leases
    {
        public DailyLease() { }

        [Required(ErrorMessage = "Please choose number of days.")]
        [Column(TypeName = "int")]
        public int numDays { get; set; }
    }
}
