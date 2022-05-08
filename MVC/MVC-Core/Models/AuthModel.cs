using Services.Decorators;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

// Written by Owen Ravelo
namespace MVC_Core.Models
{
    public class AuthModel
    {
        [JsonPropertyName("username")]
        [Required]
        [StringSize(3, 20, ErrorMessage = "Username must be no shorter than 3 characters and no longer than 20")]
        public string Username { get; set; } = string.Empty;

        [PasswordContainsAttribue(ErrorMessage = "Password must contain at least 1 lowercase, 1 uppercase, 1 symbol ('# ? ! @ $ % ^ & * -'), and 1 number")]
        [StringSize(9, 40, ErrorMessage = "Password must be no shorter than 9 characters and no longer than 40")]
        [JsonPropertyName("password")]
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
