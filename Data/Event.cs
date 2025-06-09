using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Data
{
    public class Event
    {
        [Required(ErrorMessage = "If you're seeing this, it means you're doing some shady stuff... This is applied automatically >:/")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Events without title wont be registered.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please select a date.")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please provide a location.")]
        [StringLength(50, ErrorMessage = "It cannot exceed 50 characters.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please provide a description.")]
        public string Description { get; set; }
    }
}
