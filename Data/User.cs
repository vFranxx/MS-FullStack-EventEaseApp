using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Data
{
    public class User
    {
        [Required(ErrorMessage = "If you're seeing this, it means you're doing some shady stuff... This is applied automatically >:/")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a name.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide an email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide a password.")]
        [DataType(DataType.Password, ErrorMessage = "Please enter a valid password.")]
        public string Password { get; set; } // In a real application, consider hashing passwords
    }
}
