using System.ComponentModel.DataAnnotations;

namespace practice_web_apis.Dtos
{
    public record LoginDto
     (
         [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        string Email,

         [Required]
        [DataType(DataType.Password)]
        string Password
     );
}
