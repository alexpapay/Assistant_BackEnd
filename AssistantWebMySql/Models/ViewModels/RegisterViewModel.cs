using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AssistantWebMySql.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("Электронная почта")]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [DisplayName("Повторите пароль")]
        public string PasswordConfirm { get; set; }
    }
}