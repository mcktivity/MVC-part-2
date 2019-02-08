using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Oblig2.Models
{
    public class UserAccount
    {
        [Key]
        public int UID { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "must be atleast 6 characters. max: 40")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "password does not match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "first name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "last name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        
        [Required(ErrorMessage = "Please give a valid e-mail.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail address")]
        public string Email { get; set; }

        [Display(Name = "Date Registered")]
        public DateTime DateRegistered { get; set; }

        public Boolean IsDeleted { get; set; }

        public Boolean IsAdmin { get; set; }

    }
}