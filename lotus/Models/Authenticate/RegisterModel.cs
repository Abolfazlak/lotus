using System;
using System.ComponentModel.DataAnnotations;

namespace lotus.Models.Authenticate
{
	public class RegisterModel
	{
        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Mobile is required")]
        public string? Mobile { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "IsAdmin is required")]
        public bool IsAdmin { get; set; }
    }
}

