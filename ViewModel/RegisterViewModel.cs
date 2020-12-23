using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime DateTimeOfBirth { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]//ErrorMessage
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

    }

    public enum Gender
    {
        None,
        Male,
        Female,
        Other
    }
}