using System.ComponentModel.DataAnnotations;

namespace LR10.Models
{
    public class RegistrationModel
    {
        [Required (ErrorMessage ="You have to input your name")]
        [RegularExpression (@"[A-Za-z]{2,15} [A-Za-z]{2,15}", ErrorMessage = "Invalid name or surname")]
        public string? Name { get; set; }

        [Required (ErrorMessage = "You have to input your email")]
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public string? Email { get; set; }

        [Required (ErrorMessage = "You have to input date")]
        [DataType (DataType.Date)]
        public DateOnly Date { get; set; }

        public string Product { get; set; }
    }
}
