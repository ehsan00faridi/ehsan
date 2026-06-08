using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
    public class RegisterDto
    {
      
        public string FirstName { get; set; } = string.Empty;

      
        public string LastName { get; set; } = string.Empty;
     
        public string Email { get; set; } = string.Empty;
        //[Required]
        //[DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The Password and Confirm password do not match")]
        public string Confirmpassword { get; set; } = string.Empty;
        //[Required]
        //[Phone]
        public string PhoneNumber {  get; set; }

    }
}
