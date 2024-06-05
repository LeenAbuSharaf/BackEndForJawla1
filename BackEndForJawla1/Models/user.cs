using System.ComponentModel.DataAnnotations;
namespace BackEndForJawla1.Models
{
    public class user
    {
        [Key]
        public int userId { get; set; }

      
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"00962(78|77|79)\d{7}", ErrorMessage = "Invalid phone number")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Password must be at least 8 characters long and include at least one letter, one number, and one special character.")]
        public string password { get; set; }

    }
}
