using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarinaProject.Models
{
    public class PowerBoat:Boat
    {
        [Required(ErrorMessage = "Please enter the number of engines.")]
        [Column(TypeName = "int(10)")]
        public int NumberOfEngines { get; set; }

        [Required(ErrorMessage = "Please enter the Fuel Type.")]
        [Column(TypeName = "varchar(50)")]
        public string FuelType { get; set; }
    }
}
