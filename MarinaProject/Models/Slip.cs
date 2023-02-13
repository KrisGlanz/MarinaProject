using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MarinaProject.Models
{
    public class Slip
    {
        
        public int slipId { get; set; }
        [Required(ErrorMessage = "Please enter width. ")]
        [Column(TypeName = "int")]
        public int width { get; set; }
        [Required(ErrorMessage = "Please enter slip length. ")]
        [Column(TypeName = "int")]
        public int slipLength { get; set; }

    }
}
