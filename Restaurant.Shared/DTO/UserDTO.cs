using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Shared
{
    public class UserDTO
    {
        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [StringLength(1024)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [StringLength(100)]
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8}$", ErrorMessage = "Invalid Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
    }
}
