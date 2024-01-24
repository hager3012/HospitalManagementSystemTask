using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Dtos
{
    public class userRegisterDto
    {
        [Required]
        public string FristName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
