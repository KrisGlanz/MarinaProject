using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarinaProject.Models
{
    public class Dock
    {

        public int DockId { get; set; }

        [Required(ErrorMessage = "Please enter a location. ")]
        [Column(TypeName ="String(50)")]
        public String Location { get; set; }

        [Required(ErrorMessage = "Please enter true or false.")]
        public bool Electricity { get; set; }

        [Required(ErrorMessage = "Please enter true or false")]
        public bool Water { get; set; }

    }
}
