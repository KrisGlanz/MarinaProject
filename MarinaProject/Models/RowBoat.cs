using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarinaProject.Models
{
    public class RowBoat : Boat
    {
        [Required(ErrorMessage = "Please enter the number of rowers.")]
        [Column(TypeName = "int")]
        public int NumberOfRowers { get; set; }

        [Required(ErrorMessage = "Please indicate weather you have a motor or not.")]
        [Column(TypeName = "varchar(10)")]
        public string Motor { get; set; }
        /*Not sure on this a bit could be used here as 1 could be true 0 would be false something we can think about */
    }
}
