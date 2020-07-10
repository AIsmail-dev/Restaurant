using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Restaurant.Data
{
    [Table("User", Schema = "Restaurant")]
    public class User
    {
        [Key]
        public int UserId { get; private set; }

        [StringLength(1024)]
        public string FullName { get; private set; }

        [StringLength(100)]
        [Required]
        [EmailAddress]
        public string Email { get; private set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8}$")]
        public string Password { get; private set; }

        public string Mobile { get; private set; }

        #region Methods

        public User(string fullName, string email, string password, string mobile)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            Mobile = mobile;
        }

        #endregion
    }
}
