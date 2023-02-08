using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarinaProject.Models
{
    public class Dock
    {
        [Key]
        public int DockId { get; set; }



        [Required(ErrorMessage = "Please enter a location. ")]
        [Column(TypeName ="varChar(75)")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please enter true or false.")]
        public bool Electricity { get; set; }

        [Required(ErrorMessage = "Please enter true or false")]
        public bool Water { get; set; }

    }
}
