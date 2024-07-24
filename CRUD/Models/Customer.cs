using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Customer
    {
        public int Id { get; set; } // entity framework know automatically its primary key
        [Required, MinLength(2, ErrorMessage = "First name is too short")]
        [DisplayName("First Name")]
        public string? FirstName { get; set; } // ? means that nullable
        [Required, MinLength(2, ErrorMessage = "First name is too short") ]
        public string? LastName { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
    }
}
