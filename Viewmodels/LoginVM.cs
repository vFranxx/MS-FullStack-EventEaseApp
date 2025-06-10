using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Viewmodels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Please provide an email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a password.")]
        public string Password { get; set; } = string.Empty;
    }
}
