using System.ComponentModel.DataAnnotations;

namespace TaskManagerWeb.Models.Dto
{
    public class ChangePasswordDto
    {

        public string CurrentPassword { get; set; } = string.Empty;
        [Required]
        [MaxLength(200)]
        public string NewPassword { get; set; } = string.Empty;
        [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = "";
    }
}
