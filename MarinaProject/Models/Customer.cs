using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarinaProject.Models
{
    public class Customer
    {
        [Key]
        public int customerId { get; set; }

        [Required(ErrorMessage = "Please enter first name.")]
        [Column(TypeName = "nvarchar(50)")]
        public string firstName { get; set; }
        
        [Required(ErrorMessage = "Please enter last name.")]
        [Column(TypeName = "nvarchar(50)")]
        public string lastName { get; set; }
        
        [Required(ErrorMessage = "Please enter address.")]
        [Column(TypeName = "nvarchar(250)")]
        public string address { get; set; }

        [Required(ErrorMessage = "Please enter phone number.")]
        [Column(TypeName = "nvarchar(15)")]
        [DisplayFormat(DataFormatString ="{0:###-###-####}")]
        [Phone]
        public string phoneNum { get; set; }

        public string leaseType { get; set; }


    }
}
