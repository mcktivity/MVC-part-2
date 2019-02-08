using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig2.Models
{
    public class Accounts
    {
        [Key]
        public int uid { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "username is required.")]
        public string username { get; set; }

        [Required(ErrorMessage = "password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "must be atleast 6 characters. max: 40")]
        public string password { get; set; }

        [Compare("password", ErrorMessage = "password does not match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string confirmpassword { get; set; }

        [Required(ErrorMessage = "first name is required.")]
        [Display(Name = "First Name")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "last name is required.")]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }


        [Required(ErrorMessage = "Please give a valid e-mail.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail address")]
        public string email { get; set; }

        [Display(Name = "Date Registered")]
        public DateTime dateregistered { get; set; }

        public Boolean isdeleted { get; set; }

        public Boolean isadmin { get; set; }
    }
}
