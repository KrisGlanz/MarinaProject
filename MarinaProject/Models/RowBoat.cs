using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarinaProject.Models
{
    public class RowBoat : Boat
    {
        [Required(ErrorMessage = "Please enter the number of rowers.")]
        [Column(TypeName = "int(10)")]
        public int NumberOfRowers { get; set; }

        [Required(ErrorMessage = "Please indicate weather you have a motor or not.")]
        [Column(TypeName = "BIT")]
        public int Motor { get; set; }
        /*Not sure on this a bit could be used here as 1 could be true 0 would be false something we can think about */
    }
}
