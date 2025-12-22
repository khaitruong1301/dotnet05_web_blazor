using System.ComponentModel.DataAnnotations;

public class RegisterDTO
{
    [Required(ErrorMessage = "Username cannot be blank !")]
    [RegularExpression(
        @"^[a-zA-Z0-9_]{6,32}$",
        ErrorMessage = "Username must be 6–32 characters long and contain only letters, numbers, and underscores (_)."
    )]
    public string userName { get; set; }
    [Required(ErrorMessage = "Password cannot be blank !")]
    [RegularExpression(
       @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9\s]).{8,32}$",
       ErrorMessage = "Password must be 8–32 characters long and include uppercase letters, lowercase letters, numbers, and special characters."
   )]
    public string password { get; set; }

    [Compare("password",ErrorMessage ="password does not match")]
    public string passwordConfirm { get; set; }
    
    
    [Required(ErrorMessage = "Email cannot be blank !")]
       [RegularExpression(
        @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        ErrorMessage = "Email is invalid"
    )]
    public string email { set; get; }
    [Required(ErrorMessage = "FullName cannot be blank !")]
    public string fullName { get; set; }

    public string gender { get; set; } = "male";

    public string country { get; set; }

}