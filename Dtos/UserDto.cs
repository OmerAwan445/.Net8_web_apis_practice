using System.ComponentModel.DataAnnotations;


namespace practice_web_apis.Dtos
{
    public record UserDto(
        [Required(ErrorMessage = "First_name is required field.")]
    string First_name,

    string Last_name,
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]

    string Email,
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]

    string Password,
        [Required]
        [DataType(DataType.Password)]
        [property: Compare(nameof(UserDto.Password))]

    string ConfirmPassword
        );

    /* public class UserDto
     {
         string? Id;
         [Required(ErrorMessage = "First_name is required field.")]
         public string First_name { get; set; }
         public string Last_name { get; set; }
         [Required(ErrorMessage = "Email is required.")]
         [DataType(DataType.EmailAddress)]
         public string Email { get; set; }
         [Required(ErrorMessage = "Password is required.")]
         [DataType(DataType.Password)]
         public string Password { get; set; }
         [Required]
         [DataType(DataType.Password)]
         [Compare(nameof(Password), ErrorMessage = "Password and Confirm Password Must Match")]
         public string ConfirmPassword { get; set; }

     } */
}
