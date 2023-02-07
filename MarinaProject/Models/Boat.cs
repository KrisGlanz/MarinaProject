using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarinaProject.Models
{
    public class Boat
    {
        public int BoatId { get; set; }
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter the type of Boat you have.")]
        [Column(TypeName = "int(10)")]
        public int BoatType { get; set; }

        [Required(ErrorMessage = "Please enter the registration number.")]
        [Column(TypeName = "int(10)")]
        public int Registration { get; set; }

        [Required(ErrorMessage = "Please enter your boat's length.")]
        [Column(TypeName = "int(10)")]
        public int BoatLength { get; set; }

        [Required(ErrorMessage = "Please enter your boat's manufacturer.")]
        [Column(TypeName = "varchar(75)")]
        public string Manufacturer { get; set; }
    }
}
