using System.ComponentModel.DataAnnotations;

namespace BlazorTest.Entities
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^\([\d]{3}\) [\d]{3}-[\d]{4}$", ErrorMessage = "Phone number must be in the format (123) 456-7890")]
        public string Phone { get; set; } = string.Empty;
    }
}
