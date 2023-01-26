using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL_Layer.Model
{
    public class User
    {

        public int UID { get; set; }
        [Required(ErrorMessage = "Please enter your User Name")]
        public String userName { get; set; }
        [Required(ErrorMessage = "Please enter your Email Address"), EmailAddress(ErrorMessage = "Please provide a valid Email Address")]
        public String emailAddress { get; set; }
        [Required(ErrorMessage = "Please enter your password"), MinLength(8, ErrorMessage = "Password is too short")]
        public String password { get; set; }
        [Required(ErrorMessage = "Please confirm your password"), Compare("password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}
