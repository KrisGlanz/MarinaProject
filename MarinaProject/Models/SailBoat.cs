using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarinaProject.Models
{
    public class SailBoat : Boat
    {
        [Required(ErrorMessage = "Please enter the keel depth.")]
        [Column(TypeName = "int")]
        public int KneelDepth { get; set; }

        [Required(ErrorMessage = "Please enter the number of sails.")]
        [Column(TypeName = "int")]
        public int NumberOfSails { get; set; }

        [Required(ErrorMessage = "Please enter the type of motor.")]
        [Column(TypeName = "varchar(35)")]
        public string? MotorType { get; set; }
    }
}
